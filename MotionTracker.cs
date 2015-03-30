/**
 *   MOTION TRACKER: Video-based software for tracking motion over time.
 *   Copyright (C) 2012. Jacqueline Kory. Sidney D'Mello. Andrew Olney.
 *   Contact: jacqueline.kory@gmail.com
 *   
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>
 * 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Runtime.InteropServices;

namespace MotionTracker
{
   /// <summary>
   /// Detects motion from a video.
   /// 
   /// The algorithm used for tracking motion steps frame-by-frame through
   /// the video and computes the amount of motion in any given frame Ft by
   /// measuring the proportion of pixels in Ft that have been displaced 
   /// (i.e., motion is greater than a predefined threshold) from a moving
   /// background model constructed on the basis of N earlier frames. The 
   /// proportion of pixels with motion provides an index of the amount of
   /// movement in each frame.
   /// 
   /// Authors: Jacqueline Kory, Andrew Olney, Sidney D'Mello
   /// Last modified 06.15.2012.
   /// 
   /// Change log:
   /// 02.06.2012 - modified to use the OpenCvSharp libraries instead
   /// of the SharperCv wrapper for OpenCV. JK.
   /// 
   /// 04.17.2012 - modified to include a GUI interface. JK.
   /// 
   /// 05.04.2012 - Small updates to comments, organization, naming. JK.
   /// 
   /// 06.15.2012 - Adding Haar classifier for face detection. JK.
   /// 
   /// 07.02.2012 - Adding simulation for testing accuracy. JK.
   /// 
   /// Other details:
   /// Built and tested on a Windows 7 x64 machine. Run in x86 mode.
   /// 
   /// </summary>
   public class MotionTracking
   {
      #region Fields

      // haar classifier xml file
      private string HAAR_XML_FILE = Constants.DEFAULT_HAAR_XML_FILE;
      private int HAAR_MIN_WIDTH = Constants.DEFAULT_HAAR_MIN_WIDTH;
      private int HAAR_MIN_HEIGHT = Constants.DEFAULT_HAAR_MIN_HEIGHT;
      private double HAAR_SCALE_FACTOR = Constants.DEFAULT_HAAR_SCALE_FACTOR;
      private int HAAR_MIN_NEIGHBORS = Constants.DEFAULT_HAAR_MIN_NEIGHBORS;

      // for recording motion tracking images, or from camera:
      private Recorder recorder;
      private Recorder camRecorder;

      // various tracking parameters (in milliseconds)
      private double MHI_DURATION = Constants.DEFAULT_MHI_DURATION;
      // number of cyclic frame buffer used for motion detection
      private int CYC_FRAME_BUF = 4; // default 4
      private int BINARY_THRESHOLD = Constants.DEFAULT_BINARY_THRESHOLD;
      private int THRESHOLD_MAX_VALUE = 1; // default 1

      // ring image buffer
      private IplImage[] buf = null;
      private int last = 0;

      // temporary images
      private IplImage mhi = null; // motion history image
      private IplImage mask = null; // valid orientation mask

      private Point LastCentroid;

      private bool STOP = false;
      private bool directory = false;

      // for writing results to files
      private System.IO.StreamWriter MotionWriter;
      private System.IO.StreamWriter CentroidWriter;
      private System.IO.StreamWriter FaceWriter;

      #region abort motion tracking / done motion tracking events

      // abort motion tracking, done motion tracking events
      public delegate void AbortMotionTracking(object sender, EventArgs e);
      public event AbortMotionTracking AbortedEvent;
      public delegate void DoneMotionTracking(object sender, EventArgs e);
      public event DoneMotionTracking DoneEvent;

      protected virtual void OnAborted(EventArgs e)
      {
         AbortedEvent(this, e);
      }
      protected virtual void OnDone(EventArgs e)
      {
         DoneEvent(this, e);
      }

      #endregion

      #endregion

      /// <summary>
      /// Default constructor
      /// </summary>
      public MotionTracking()
      {
      }

      /// <summary>
      /// Run test - reads in a sample video file, outputs motion file
      /// </summary>
      /// <param name="visualization">true to make visualizer show</param>
      /// <param name="outputMotionSilh">false if none</param>
      public void RunDemo(bool visualization, bool graph,
          bool outputMotionSilh, bool outputFace)
      {
         // process a sample video file
         RunFile(Constants.SAMPLE_VIDEO,
             Directory.GetCurrentDirectory() + "\\",
             visualization, graph,
             outputMotionSilh,
             Constants.NO_LIVE_CAM, null,
             outputFace);
      }

      /// <summary>
      /// run simulated images
      /// </summary>
      /// <param name="visualization"></param>
      /// <param name="graph"></param>
      /// <param name="outputMotionSilh"></param>
      /// <param name="outputFace"></param>
      /// <param name="outPath"></param>
      public void RunSimulation(bool visualization, bool graph,
         bool outputMotionSilh, bool outputFace, string outPath)
      {
         // will write summary line for each parameter set to this file
         StreamWriter overallWriter = new StreamWriter(outPath 
            + Constants.SIM_FILE_OVERALL, true);
         overallWriter.WriteLine(Constants.SIM_OVERALL_HEADER);
         overallWriter.Flush();
         overallWriter.Close();

         // trial counter
         int trial = -1;
         int binthr = 30; // ****

         // for each external param setting and each internal param setting,
         // run X trials of Y seconds each, at 30fps = Y*30 frames

         // for each level of noise
         for (int noise = Constants.NOISE_MIN; noise <= Constants.NOISE_MAX;
            noise += Constants.NOISE_INCR)
         {
            for (int areaMult = Constants.AREA_MIN; 
               areaMult <= Constants.AREA_MAX;
               areaMult += Constants.AREA_INCR)
            {
               // area (thus radius) is a percentage of the image size
               //**int radius = (int) (Math.Sqrt((areaMult * 
               //**   Constants.SIM_IMG_HEIGHT * Constants.SIM_IMG_WIDTH / 100.0)
               //**   /Math.PI));
               // square ***
               int radius = (int) Math.Sqrt((areaMult * 
                  Constants.SIM_IMG_HEIGHT * Constants.SIM_IMG_WIDTH / 100.0));

               // for each level of speed
               for (int speedMult = Constants.SPEED_MIN;
                  speedMult <= Constants.SPEED_MAX; 
                  speedMult += Constants.SPEED_INCR)
               {
                  // speed is a percentage of the circle's size
                  int speed = (int)(radius * (speedMult / 100.0)); //px/frame //**circle radius*2
                  if (speed < 1) speed = 1;
                  //**if (speed >= radius * 2) speed = radius*2 - 1;
                  //square ***
                  if (speed > radius) speed = radius - 1;

                  //**** not running with binary threshold -- is black and white!
                  // for each binary threshold setting
                  //for (int binthr = Constants.BINTHR_MIN;
                  //   binthr <= Constants.BINTHR_MAX;
                  //   binthr += Constants.BINTHR_INCR)
                  //{
                     // for each MHI duration setting
                     for (double mhidMult = Constants.MHI_MIN; mhidMult <= Constants.MHI_MAX;
                        mhidMult += Constants.MHI_INCR)
                     {
                        // update mhi_incr
                        //Constants.MHI_INCR = (mhidMult < 10 ? 1 : mhidMult < 50 ? 2 : 5);

                        // mhi duration is a percentage of speed
                        // speed = distance/time = pixels/frame
                        // mhid = % * speed (px/frame) * fps
                        //int mhid = (int) ((speed * Constants.SIM_FPS) * 
                        //   (mhidMult / 100.0));
                        double mhid = ((speed * Constants.SIM_FPS) *
                           (mhidMult / 100.0));
                        if (mhid < 1) mhid = 1; 
                        // because we need mhid in ms, and 1ms is smallest we can use

                        // write line to file for each of the 100 trials with 
                        // summary (mean, stdev) for that trial
                        string trialBase = "-size" + areaMult.ToString()
                           + "-noise" + noise.ToString()
                           + "-speed" + speedMult.ToString()
                           + "-mhid" + mhidMult.ToString(); 
                           //+ "-binthr" + binthr.ToString(); //****
                        //StreamWriter trialSummaryWriter = new StreamWriter(
                        //   outPath + Constants.SIM_FILE_TRIAL_SUMMARY_BASE
                        //   + trialBase + "-summary.txt", true);
                        //trialSummaryWriter.WriteLine(
                        //   Constants.SIM_TRIAL_SUMMARY_HEADER);
                        //trialSummaryWriter.Flush();
                        //trialSummaryWriter.Close();

                        //List<double> trialEstimatedMeans = new List<double>();
                        //List<double> trialEstimatedStds = new List<double>();
                        //List<double> trialActualMeans = new List<double>();
                        //List<double> trialActualStds = new List<double>();

                        // run some samples per trial with these settings
                        // get mean and standard deviation for each iteration
                        // then average the results
                        trial++;
                        for (int iteration = 0; iteration < Constants.ITERATIONS; iteration++) 
                        { 
                           // set internal parameters
                           SetInternalParameters((double)mhid, binthr, -1, -1, -1,
                              -1, "");
                           // create simulation object with external parameters
                           MotionTracker.Simulation sim = new MotionTracker.Simulation(
                              Constants.SIM_IMG_WIDTH, Constants.SIM_IMG_HEIGHT,
                              radius, noise, Constants.SPEED_MIN, speed);
                           // file name
                           string outfile = Constants.SIM_FILE_BASE + trialBase//;
                               + "-iteration"
                               + (iteration < 10 ? "0" : "") + iteration.ToString();
                           // mean, stdev
                           double[] estimatedMean = {0,0,0};
                           double[] estimatedStdev = { 0, 0, 0 };
                           double[] actualMean = { 0, 0, 0 };
                           double[] actualStdev = { 0, 0, 0 };
                           double[] pearsonCorr = { 0, 0, 0, 0, 0, 0, 0 };
                           // display params before starting trial
                           //MessageBox.Show("parameters:\r\n noise " + noise 
                           //   + "\r\n speed " + speedMult 
                           //   + "\r\n size " + areaMult
                           //   + "\r\n mhi duration " + mhid
                           //   + "\r\n binary threshold " + binthr);

                           // simulate
                           RunSim(outfile, outPath, visualization, graph,
                              outputMotionSilh, outputFace, sim, out estimatedMean,
                              out estimatedStdev, out actualMean, out actualStdev,
                              out pearsonCorr);

                           // write summary line to file for this trial
                           //trialSummaryWriter = new StreamWriter(
                           //outPath + Constants.SIM_FILE_TRIAL_SUMMARY_BASE
                           //+ trialBase + "-summary.txt", true);
                           //trialSummaryWriter.WriteLine(trials + //**IF TRIALS
                           //   "\t" + Constants.SIM_IMG_WIDTH + "\t"
                           //   + Constants.SIM_IMG_HEIGHT + "\t"
                           //   + radius + "\t" + noise + "\t"
                           //   + speed + "\t" + mhid + "\t"
                           //   + binthr + "\t" +
                           //   actualMean + "\t" + actualStdev
                           //   + estimatedMean + "\t"
                           //   + estimatedStdev + "\t");
                           //trialSummaryWriter.Flush();
                           //trialSummaryWriter.Close();

                           // and update list of means/stdevs for calculating 
                           // overall for this parameter set
                           //trialEstimatedMeans.Add(estimatedMean);
                           //trialEstimatedStds.Add(estimatedStdev);
                           //trialActualMeans.Add(actualMean);
                           //trialActualStds.Add(actualStdev);
                           //} //**IF TRIALS
                           // ***commented out trial stats file
                           // ***moving all to the overall file, with one line
                           // per sample, rather than aggregating the samples
                           // here. 


                           // write line to file for all samples
                           overallWriter = new StreamWriter(outPath
                              + Constants.SIM_FILE_OVERALL, true);
                           overallWriter.WriteLine(trial + "\t" +
                                 iteration + "\t"
                                 + Constants.SIM_IMG_WIDTH + "\t"
                                 + Constants.SIM_IMG_HEIGHT + "\t"
                                 + areaMult + "\t" + radius + "\t" 
                                 + speedMult + "\t" + speed + "\t"
                                 + noise + "\t" + binthr + "\t" //****
                                 + mhidMult + "\t" + mhid + "\t"
                              //** only using proportion2, so commented out the rest:
                                 //+ actualMean[0] + "\t" + actualStdev[0] + "\t"
                                 + actualMean[1] + "\t" + actualStdev[1] + "\t"
                                 //+ actualMean[2] + "\t" + actualStdev[2] + "\t"
                                 //+ estimatedMean[0] + "\t" + estimatedStdev[0] + "\t"
                                 + estimatedMean[1] + "\t" + estimatedStdev[1] + "\t"
                                 //+ estimatedMean[2] + "\t" + estimatedStdev[2] + "\t"
                                 //+ estimatedMean[3] + "\t" + estimatedMean[3] + "\t"
                                 //+ pearsonCorr[0] + "\t" 
                                 + pearsonCorr[1] //+ "\t"
                                 //+ pearsonCorr[2] + "\t" + pearsonCorr[3] + "\t"
                                 //+ pearsonCorr[4] + "\t" + pearsonCorr[5]
                                 //+ "\t" + pearsonCorr[6]
                                 );
                           overallWriter.Flush();
                           overallWriter.Close();
                        }
                     }
                  //} // ****
               }
            }
         }

         OnDone(new EventArgs()); // send done message
      }

      /// <summary>
      /// Run program on a whole directory of files
      /// </summary>
      /// <param name="InPath"></param>
      /// <param name="OutPath"></param>
      /// <param name="visualization"></param>
      /// <param name="outputMotion"></param>
      public void RunDirectory(String InPath, String OutPath,
         bool visualization, bool graph, bool outputMotion,
         bool outputFace)
      {
         // write any errors with directory to file
         StreamWriter ErrReport = new StreamWriter(OutPath + "TrackErrors.txt");
         this.directory = true;
         int filecounter = 0;
         string[] files = Directory.GetFiles(InPath);

         foreach (String InFileName in files)
         {
            try
            {
               // check file extensions for video files only
               if (Path.GetExtension(InFileName).Equals(".avi"))
               {
                  // returns false if aborted
                  if (!RunFile(InFileName, OutPath, visualization, graph,
                      outputMotion, Constants.NO_LIVE_CAM, null,
                      outputFace))
                  {
                     ErrReport.Close();
                     this.directory = false;
                     OnAborted(new EventArgs());
                     this.STOP = false;
                     return;
                  }
               }
               else
               {
                  ErrReport.WriteLine("Error with " + InFileName +
                      "\t" + "Not a valid AVI file.");
               }
            }
            catch (Exception ex)
            {
               //Console.WriteLine("Error with " + ex.StackTrace);
               ErrReport.WriteLine("Error with " + InFileName +
                   "\t" + ex.Message);
               ErrReport.Flush();
            }

            filecounter++;

         }
         ErrReport.Close();
         this.directory = false;
         OnDone(new EventArgs()); // send done message

         //Console.WriteLine("DONE");
         //Console.ReadLine();
      }

      /// <summary>
      /// Run motion tracking program on a file - JK 03.27.2012
      /// </summary>
      /// <param name="aviFile">input video file name</param>
      /// <param name="visualization">run visualizer if true</param>
      /// <param name="motion_video">output motion video file if true</param>
      public bool RunFile(string aviFile, string outPath,
          bool visualization, bool showGraph, bool outputMotion,
          int camIndex, string camOutput, bool outputFace)
      {
         // get output file names
         String outputBase = "";
         if (aviFile != null) outputBase =
             (aviFile.Equals("") ? Constants.DEFAULT_OUTPUT_BASE_NAME
             : Path.GetFileNameWithoutExtension(aviFile)); // if input file
         else if (camOutput != null) outputBase =
             (camOutput.Equals("") ? Constants.DEFAULT_OUTPUT_BASE_NAME
             : Path.GetFileNameWithoutExtension(camOutput)); // if live cam

         String motionFile = outPath + outputBase + Constants.MOTION_OUTPUT;
         String centroidFile = outPath + outputBase + Constants.CENTROID_OUTPUT;
         String faceFile = outPath + outputBase + Constants.FACE_OUTPUT;

         //Console.WriteLine("PROCESSING: " + (avi_file.Equals("") ?
         //    Constants.DEFAULT_OUTPUT_BASE_NAME :
         //    Path.GetFileName(avi_file)));

         LastCentroid = new Point(0, 0);

         // set up recorder for saving motion silhouette video to file
         if (outputMotion)
            recorder = new Recorder(outPath + outputBase +
               Constants.MOTION_SILH_OUTPUT);

         // set up recorder for saving live camera to file
         if (camOutput != null && !camOutput.Equals(""))
         {
            this.camRecorder = new Recorder(outPath + camOutput);
         }

         // set up results streamwriters
         try
         {
            this.MotionWriter = new System.IO.StreamWriter(motionFile);
            this.CentroidWriter = new System.IO.StreamWriter(centroidFile);
            if (outputFace) this.FaceWriter = new System.IO.StreamWriter(faceFile);
         }
         catch (Exception ex)
         {
            System.Diagnostics.Trace.WriteLine(ex.ToString());
            this.MotionWriter = new System.IO.StreamWriter(
                Path.GetFileNameWithoutExtension(motionFile) + "01"
                + Path.GetExtension(motionFile));
            this.CentroidWriter = new System.IO.StreamWriter(
                Path.GetFileNameWithoutExtension(centroidFile) + "01"
                + Path.GetExtension(centroidFile));
            if (outputFace) this.FaceWriter = new System.IO.StreamWriter(
                Path.GetFileNameWithoutExtension(faceFile) + "01"
                + Path.GetExtension(faceFile));
         }

         IplImage theFrame; // get first frame later
         double frameNo = 0;

         // create the Haar Classifier
         CvHaarClassifierCascade hc = CvHaarClassifierCascade.FromFile(
               this.HAAR_XML_FILE);
         CvMemStorage hcStorage = new CvMemStorage();;
         // previously:
         //ClassifierCascade c = new CvHaarClassifierCascade(
         //      "<default_face_cascade>", new CvSize(24, 24));
         //HiddenClassifierCascade hc = new HiddenClassifierCascade(
         //      c, null, null, null, 1);

         IplImage motion = null; // motion for each frame

         // setup video source
         CvCapture theSrc;

         // run from file, not live camera feed
         if (camIndex == Constants.NO_LIVE_CAM)
         {
             //theSrc = CvCapture.FromFile(aviFile);
             theSrc = new CvCapture(Path.IsPathRooted(aviFile) ? aviFile
               : (System.IO.Directory.GetCurrentDirectory() + "\\" + aviFile));
             
         }
         // or run from live camera feed
         else
         {
            theSrc = new CvCapture(CaptureDevice.Any, camIndex);
         }

         for (; ; )     // now run the frame grab and detect loop
         {
            theFrame = theSrc.QueryFrame(); // get frame
            frameNo++; // update frame counter

            // not using these b/c opencv ref says they're not working
            // completely right -- frame no. is off
            //int fn = theSrc.PosFrames;
            //int fms = theSrc.PosMsec;

            if (this.camRecorder != null)
               this.camRecorder.record(theFrame);

            // break if no frame or if told to stop
            if (theFrame == null || this.STOP)
            {
               break;
            }

            // otherwise, init motion image if we haven't yet
            else
            {
               if (motion == null)
               {
                  motion = new IplImage(theFrame.Size, BitDepth.U8, 3);
               }
            }

            // now update motion, energy level, centroid:
            // (input, output, binary threshold)
            update_mhi(theFrame, motion, BINARY_THRESHOLD);

            double energy_level = getEnergyLevel(motion);
            try
            {
               if (this.MotionWriter != null)
               {
                  this.MotionWriter.WriteLine(frameNo + "\t"
                     //+ fn + "\t" // not in use b/c opencv cvcapt props
                     //+ fms + "\t" // for no. frames & ms are off
                      + energy_level);
               }
            }
            catch (Exception ex)
            {
               System.Diagnostics.Trace.WriteLine(ex.ToString());
            }

            Point Centroid = getCentroid(motion);
            try
            {
               if (this.CentroidWriter != null)
               {
                  this.CentroidWriter.WriteLine(frameNo + "\t" +
                      Centroid.X + "\t" + Centroid.Y);
               }
            }
            catch (Exception ex)
            {
               System.Diagnostics.Trace.WriteLine(ex.ToString());
            }

            #region Do Haar
            if (outputFace)
            {
               try
               {
                  // find the face(s) within the image with Haar
                  // using parameters based on what was used previously here
                  hcStorage.Clear();
                  CvSeq<CvAvgComp> faces = Cv.HaarDetectObjects(theFrame, hc,
                     hcStorage, HAAR_SCALE_FACTOR, HAAR_MIN_NEIGHBORS, 
                     HaarDetectionType.DoCannyPruning,
                     new CvSize(HAAR_MIN_WIDTH, HAAR_MIN_HEIGHT));
                  // previously:
                  // CvRect[] faces = hc.DetectObjects(theFrame, 1.2, 2,
                  //   PruningFlags.CannyPruning);

                  // place all rectangles found on the image
                  // but only save/print the largest rect
                  string line = frameNo.ToString();
                  CvRect rect = new CvRect();
                  for (int i = 0; i < faces.Total; i++)
                  {
                     theFrame.Rectangle(faces[i].Value.Rect, CvColor.Green, 3);
                     // not using classifier yet

                     // if this rectangle is bigger than the one we have saved
                     // then save it instead
                     if (faces[i].Value.Rect.Width // area
                        * faces[i].Value.Rect.Height > rect.Width * rect.Height)
                        rect = faces[i].Value.Rect;
                  }

                  // then print this data to file:

                  // at present, only print the largest rectangle. if there
                  // are others (there should only ever be one in this case,
                  // b/c only one person in each video), then modify here to
                  // print out each in separate set of columns on same line

                  line += "\t" + rect.Top // top coordinate
                     + "\t" + rect.Left // left coordinate
                     + "\t" + rect.Width // width
                     + "\t" + rect.Height // height
                     + "\t" + rect.Width * rect.Height; // area

                  // get motion of JUST the space within the rectangle
                  // i.e., motion of just the found face
                  line += "\t";
                  if (rect.Width > 0)
                  {
                     motion.SetROI(rect); //if no face found, no motion to calc
                     motion.ROI = rect;
                     IplImage motionFace = Cv.CreateImage(rect.Size, motion.Depth, motion.NChannels);
                     Cv.Copy(motion, motionFace);
                     motion.ResetROI(); // later want to show whole img, not just face

                     line += getEnergyLevel(motionFace).ToString();
                  }
                  else
                  {
                  }

                  // write line to file
                  try
                  {
                     if (this.FaceWriter != null)
                     {
                        this.FaceWriter.WriteLine(line);
                     }
                  }
                  catch (Exception ex)
                  {
                     System.Diagnostics.Trace.WriteLine(ex.ToString());
                  }

                  faces.Dispose();
                  
                  // previously:
                  // place the frame(s) on the image
                  /*for (int i=0; i < faces.Length; i++) 
                  {					
                     theFrame.Rectangle(faces[i], new CvColor(255,255,0), 3);
					
                     //Send face rawData to classifier
                     //motion.SetImageROI( faces[ i ] ); //Set ROI to found face, 
                     //// so we only send classifier this face
                     //SharperCVExtensions.MyCvImage normalized = 
                     //   new SharperCVExtensions.MyCvImage( 
                     //   new SharperCV.CvSize( this.imageDimensions, 
                     //   this.imageDimensions ), SharperCV.BitDepths.IPL_DEPTH_8U, 3 );
                     //SharperCVExtensions.Extensions.cvResize( motion.myArrHandle,
                     //   normalized.myArrHandle, 0 ); //Resize to uniform size for classifier
                     //motion.ResetImageROI();	//Reset ROI
                     //string className = classify( motion );
                     //motion.PutText( className, faces[ i ].Points[ 0 ],
                     //   SharperCV.CvColor.Crimson );
                   }*/
               }
               catch (Exception ex)
               {
                  System.Diagnostics.Trace.WriteLine(ex.ToString());
               }
            }
            #endregion  

            // display the image
            if (visualization)
            {
               // set motion silhouette image in UI
               MotionTracker.Program.motionTrackerUI.SetMotionSilh(motion);
               // set video frame image in UI
               MotionTracker.Program.motionTrackerUI.SetVideoFrame(theFrame);
            }

            // display moving time series graph
            if (showGraph)
            {
               MotionTracker.Program.motionTrackerUI.UpdateMovingTimeSeries(energy_level);
            }

            if (recorder != null)
               recorder.record(motion);

         } // end for

         // properly close everything after finishing or after STOP:
         #region end stuff
         if (!theSrc.IsDisposed) theSrc.Dispose();

         if (recorder != null)
            recorder.finalize();

         if (this.camRecorder != null)
            this.camRecorder.finalize();

         if (!hc.IsDisposed)
            hc.Dispose();
         if (!hcStorage.IsDisposed)
            hcStorage.Dispose();

         try
         {
            if (this.MotionWriter != null)
            {
               this.MotionWriter.Flush();
               this.MotionWriter.Close();
            }
         }
         catch (Exception ex)
         {
            System.Diagnostics.Trace.WriteLine(ex.ToString());
         }
         try
         {
            if (this.CentroidWriter != null)
            {
               this.CentroidWriter.Flush();
               this.CentroidWriter.Close();
            }
         }
         catch (Exception ex)
         {
            System.Diagnostics.Trace.WriteLine(ex.ToString());
         }
         try
         {
            if (this.FaceWriter != null)
            {
               this.FaceWriter.Flush();
               this.FaceWriter.Close();
            }
         }
         catch (Exception ex)
         {
            System.Diagnostics.Trace.WriteLine(ex.ToString());
         }

         // finished cleaning up

         // if running a directory and aborted, return false
         // send aborted message from rundir function
         if (this.directory && this.STOP)
            return false;

         // if aborted and not running a directory
         if (this.STOP)
         {
            OnAborted(new EventArgs());
            this.STOP = false;
            return false;
         }
         // if finished normally, running a single file
         // (if running a directory, send done message from there instead)
         else if (!this.directory)
         {
            OnDone(new EventArgs());
         }

         return true;
         #endregion
      }

      /// <summary>
      /// Run motion tracking program on a file - JK 03.27.2012
      /// </summary>
      /// <param name="visualization">run visualizer if true</param>
      /// <param name="motion_video">output motion video file if true</param>
      public void RunSim(string outfile, string outPath,
         bool visualization, bool showGraph, bool outputMotion,
         bool outputFace, MotionTracker.Simulation sim, 
         out double[] estimatedMean, out double[] estimatedStdev,
         out double[] actualMean, out double[] actualStdev,
         out double[] pearsonCorr)
      {
         // get output file names
         String motionFile = outPath + outfile + Constants.MOTION_OUTPUT;

         // set up recorder for saving motion silhouette video to file
         if (outputMotion)
            this.recorder = new Recorder(outPath + outfile +
               Constants.MOTION_SILH_OUTPUT);

         // set up recorder for saving face video to file
         if (Constants.SAVE_SIM)
            this.camRecorder = new Recorder(outPath + outfile +
               Constants.SIM_OUTPUT, Constants.SIM_FPS, 
               Constants.SIM_IMG_WIDTH, Constants.SIM_IMG_HEIGHT);

         // set up results streamwriters
         try
         {
            this.MotionWriter = new System.IO.StreamWriter(motionFile);
         }
         catch (Exception ex)
         {
            System.Diagnostics.Trace.WriteLine(ex.ToString());
            this.MotionWriter = new System.IO.StreamWriter(
                Path.GetFileNameWithoutExtension(motionFile) + "01"
                + Path.GetExtension(motionFile));
         }

         this.MotionWriter.WriteLine(Constants.MOTION_HEADER);

         List<double> estimatedMotionProp2 = new List<double>();
         List<double> actualMotionProp2 = new List<double>();
         List<double> estimatedMotionProp1 = new List<double>();
         List<double> actualMotionProp1 = new List<double>();
         List<double> estimatedMotionThisFrame = new List<double>();
         List<double> actualMotionThisFrame = new List<double>();
         List<double> estimatedMotionProp3 = new List<double>();

         // set up lists for out stuff
         estimatedMean = new double[] { 0, 0, 0, 0 };
         estimatedStdev = new double[] { 0, 0, 0, 0 };
         actualMean = new double[] { 0, 0, 0 };
         actualStdev = new double[] { 0, 0, 0 };
         pearsonCorr = new double[] { 0, 0, 0, 0, 0, 0, 0};

         IplImage theFrame; // get first frame later
         IplImage motion = null; // motion for each frame
         IplImage prevMotion = null; // previous frame of motion
         
         // now run the frame grab and detect loop
         for (int frames = 0; frames < Constants.SECONDS * Constants.SIM_FPS;
            frames++)     
         {
            theFrame = sim.NextFrame(); // get frame

            if (this.camRecorder != null) // if recording video to file
               this.camRecorder.record(theFrame);

            // break if no frame or if told to stop
            if (theFrame == null || this.STOP)
            {
               break;
            }

            // otherwise, init motion image if we haven't yet
            else
            {
               if (motion == null)
               {
                  motion = new IplImage(theFrame.Size, BitDepth.U8, 3);
               }
               if (prevMotion == null)
               {
                  prevMotion = new IplImage(theFrame.Size, BitDepth.U8, 3);
               }
            }

            // now update motion:
            // (input, output, binary threshold)
            update_mhi(theFrame, motion, BINARY_THRESHOLD);
            double energy_level = getEnergyLevel(motion);
            // ***only using proportion2, so commented out the rest:
            //double prop_energy_level, prop2_energy_level, prop3_energy_level;
            double prop2_energy_level;
            GetProportionEnergy(motion, prevMotion, //out prop_energy_level, 
               out prop2_energy_level);//, out prop3_energy_level);
            prevMotion = Cv.CloneImage(motion);

            estimatedMotionProp2.Add(prop2_energy_level);
            //estimatedMotionProp1.Add(prop_energy_level);
            //estimatedMotionThisFrame.Add(energy_level);
            //estimatedMotionProp3.Add(prop3_energy_level);

            //actualMotionProp1.Add(sim.actualMovementProportion);
            actualMotionProp2.Add(sim.actualMovementProp2);
            //actualMotionThisFrame.Add(sim.actualMovementThisFrame);

            try
            {
               if (this.MotionWriter != null)
               {
                  this.MotionWriter.WriteLine((frames + 1).ToString()
                     + "\t" + sim.actualMovementProportion
                     + "\t" + sim.actualMovementProp2
                     + "\t" + sim.actualMovementThisFrame
                     + "\t" + energy_level
                     //+ "\t" + prop_energy_level
                     + "\t" + prop2_energy_level
                     //+ "\t" + prop3_energy_level
                     );
               }
            }
            catch (Exception ex)
            {
               System.Diagnostics.Trace.WriteLine(ex.ToString());
            }

            // display the image
            if (visualization)
            {
               // set motion silhouette image in UI
               MotionTracker.Program.motionTrackerUI.SetMotionSilh(motion);
               // set video frame image in UI
               MotionTracker.Program.motionTrackerUI.SetVideoFrame(theFrame);
            }

            // display moving time series graph
            if (showGraph)
            {
               MotionTracker.Program.motionTrackerUI.UpdateMovingTimeSeries(energy_level);
            }

            if (recorder != null) // if recording motion video to file
               recorder.record(motion);

         } // end for


         // calculate means and standard deviations
         //estimatedMean[0] = (MathNet.Numerics.Statistics.Statistics.Mean(
         //   //estimatedMotion);
         //   estimatedMotionProp1.GetRange(Constants.SIM_FPS,
         //   estimatedMotionProp1.Count - Constants.SIM_FPS)));
         //estimatedStdev[0] = (MathNet.Numerics.Statistics.Statistics.StandardDeviation(
         //   //estimatedMotion);
         //   estimatedMotionProp1.GetRange(Constants.SIM_FPS,
         //   estimatedMotionProp1.Count - Constants.SIM_FPS)));
         //actualMean[0] = (MathNet.Numerics.Statistics.Statistics.Mean(
         //   //actualMotion);
         //   actualMotionProp1.GetRange(Constants.SIM_FPS,
         //   actualMotionProp1.Count - Constants.SIM_FPS)));
         //actualStdev[0] = (MathNet.Numerics.Statistics.Statistics.StandardDeviation(
         //   //actualMotion);
         //   actualMotionProp1.GetRange(Constants.SIM_FPS,
         //   actualMotionProp1.Count - Constants.SIM_FPS)));
         //pearsonCorr[0] = (MathNet.Numerics.Statistics.Correlation.Pearson(
         //   //estimatedMotion, actualMotion);
         //   estimatedMotionProp1.GetRange(Constants.SIM_FPS,
         //   estimatedMotionProp1.Count - Constants.SIM_FPS),
         //   actualMotionProp1.GetRange(Constants.SIM_FPS,
         //   actualMotionProp1.Count - Constants.SIM_FPS)));

         // calculate means and standard deviations
         estimatedMean[1] = (MathNet.Numerics.Statistics.Statistics.Mean(
            //estimatedMotion);
            estimatedMotionProp2.GetRange(Constants.SIM_FPS, 
            estimatedMotionProp2.Count - Constants.SIM_FPS)));
         estimatedStdev[1] = (MathNet.Numerics.Statistics.Statistics.StandardDeviation(
            //estimatedMotion);
            estimatedMotionProp2.GetRange(Constants.SIM_FPS,
            estimatedMotionProp2.Count - Constants.SIM_FPS)));
         actualMean[1] = (MathNet.Numerics.Statistics.Statistics.Mean(
            //actualMotion);
            actualMotionProp2.GetRange(Constants.SIM_FPS,
            actualMotionProp2.Count - Constants.SIM_FPS)));
         actualStdev[1] = (MathNet.Numerics.Statistics.Statistics.StandardDeviation(
            //actualMotion);
            actualMotionProp2.GetRange(Constants.SIM_FPS,
            actualMotionProp2.Count - Constants.SIM_FPS)));
         pearsonCorr[1] = (MathNet.Numerics.Statistics.Correlation.Pearson(
            //estimatedMotion, actualMotion);
            estimatedMotionProp2.GetRange(Constants.SIM_FPS,
            estimatedMotionProp2.Count - Constants.SIM_FPS),
            actualMotionProp2.GetRange(Constants.SIM_FPS,
            actualMotionProp2.Count - Constants.SIM_FPS)));

         // calculate means and standard deviations
         //estimatedMean[2] = (MathNet.Numerics.Statistics.Statistics.Mean(
         //   //estimatedMotion);
         //   estimatedMotionThisFrame.GetRange(Constants.SIM_FPS,
         //   estimatedMotionThisFrame.Count - Constants.SIM_FPS)));
         //estimatedStdev[2] = (MathNet.Numerics.Statistics.Statistics.StandardDeviation(
         //   //estimatedMotion);
         //   estimatedMotionThisFrame.GetRange(Constants.SIM_FPS,
         //   estimatedMotionThisFrame.Count - Constants.SIM_FPS)));
         //actualMean[2] = (MathNet.Numerics.Statistics.Statistics.Mean(
         //   //actualMotion);
         //   actualMotionThisFrame.GetRange(Constants.SIM_FPS,
         //   actualMotionThisFrame.Count - Constants.SIM_FPS)));
         //actualStdev[2] = (MathNet.Numerics.Statistics.Statistics.StandardDeviation(
         //   //actualMotion);
         //   actualMotionThisFrame.GetRange(Constants.SIM_FPS,
         //   actualMotionThisFrame.Count - Constants.SIM_FPS)));
         //pearsonCorr[2] = (MathNet.Numerics.Statistics.Correlation.Pearson(
         //   //estimatedMotion, actualMotion);
         //   estimatedMotionThisFrame.GetRange(Constants.SIM_FPS,
         //   estimatedMotionThisFrame.Count - Constants.SIM_FPS),
         //   actualMotionThisFrame.GetRange(Constants.SIM_FPS,
         //   actualMotionThisFrame.Count - Constants.SIM_FPS)));

         //// calculate means and standard deviations
         //estimatedMean[3] = (MathNet.Numerics.Statistics.Statistics.Mean(
         //   //estimatedMotion);
         //   estimatedMotionProp3.GetRange(Constants.SIM_FPS,
         //   estimatedMotionProp3.Count - Constants.SIM_FPS)));
         //estimatedStdev[3] = (MathNet.Numerics.Statistics.Statistics.StandardDeviation(
         //   //estimatedMotion);
         //   estimatedMotionProp3.GetRange(Constants.SIM_FPS,
         //   estimatedMotionProp3.Count - Constants.SIM_FPS)));

         //pearsonCorr[3] = (MathNet.Numerics.Statistics.Correlation.Pearson(
         //   estimatedMotionProp2.GetRange(Constants.SIM_FPS,
         //   estimatedMotionProp2.Count - Constants.SIM_FPS),
         //   actualMotionProp1.GetRange(Constants.SIM_FPS,
         //   actualMotionProp1.Count - Constants.SIM_FPS)));

         //pearsonCorr[4] = (MathNet.Numerics.Statistics.Correlation.Pearson(
         //   estimatedMotionProp1.GetRange(Constants.SIM_FPS,
         //   estimatedMotionProp1.Count - Constants.SIM_FPS),
         //   actualMotionProp2.GetRange(Constants.SIM_FPS,
         //   actualMotionProp2.Count - Constants.SIM_FPS)));


         //pearsonCorr[5] = (MathNet.Numerics.Statistics.Correlation.Pearson(
         //   estimatedMotionProp3.GetRange(Constants.SIM_FPS,
         //   estimatedMotionProp3.Count - Constants.SIM_FPS),
         //   actualMotionProp1.GetRange(Constants.SIM_FPS,
         //   actualMotionProp1.Count - Constants.SIM_FPS)));


         //pearsonCorr[6] = (MathNet.Numerics.Statistics.Correlation.Pearson(
         //   estimatedMotionProp3.GetRange(Constants.SIM_FPS,
         //   estimatedMotionProp3.Count - Constants.SIM_FPS),
         //   actualMotionProp2.GetRange(Constants.SIM_FPS,
         //   actualMotionProp2.Count - Constants.SIM_FPS)));



         // properly close everything after finishing or after STOP:
         #region end stuff
         if (recorder != null)
            recorder.finalize();

         if (this.camRecorder != null)
            this.camRecorder.finalize();
         try
         {
            if (this.MotionWriter != null)
            {
               this.MotionWriter.Flush();
               this.MotionWriter.Close();
            }
         }
         catch (Exception ex)
         {
            System.Diagnostics.Trace.WriteLine(ex.ToString());
         }
         try
         {
            if (this.CentroidWriter != null)
            {
               this.CentroidWriter.Flush();
               this.CentroidWriter.Close();
            }
         }
         catch (Exception ex)
         {
            System.Diagnostics.Trace.WriteLine(ex.ToString());
         }

         // finished cleaning up

         // if aborted
         if (this.STOP)
         {
               OnAborted(new EventArgs());
               this.STOP = false;
         }

         #endregion
      }

      /// <summary>
      /// Stop processing
      /// </summary>
      public void StopProcessing()
      {
         this.STOP = true;
      }

      /// <summary>
      /// set internal motion tracking parameters
      /// </summary>
      /// <param name="mhi_duration">"memory" length of MHI in seconds</param>
      /// <param name="binary_threshold">for thresholding silhouette image</param>
      public void SetInternalParameters(double mhiDuration,
          int binaryThreshold, double haarScaleFactor, int haarMinNeighbors,
          int haarMinWidth, int haarMinHeight, string haarXMLFile)
      {
         if (mhiDuration >= 0)
            this.MHI_DURATION = mhiDuration;

         if (binaryThreshold >= 0)
            this.BINARY_THRESHOLD = binaryThreshold;

         if (haarScaleFactor >= 1)
            this.HAAR_SCALE_FACTOR = haarScaleFactor;

         if (haarMinNeighbors >= 0)
            this.HAAR_MIN_NEIGHBORS = haarMinNeighbors;

         if (haarMinWidth >= 0)
            this.HAAR_MIN_WIDTH = haarMinWidth;

         if (haarMinHeight >= 0)
            this.HAAR_MIN_HEIGHT = haarMinHeight;

         if (!haarXMLFile.Equals("") &&
            Directory.Exists(Path.GetDirectoryName(haarXMLFile))
            && Path.GetExtension(haarXMLFile).Equals(".xml"))
            this.HAAR_XML_FILE = haarXMLFile;
      }

      /// <summary>
      /// Get centroid
      /// </summary>
      /// <param name="iplImage"></param>
      /// <returns></returns>
      private Point getCentroid(IplImage iplImage)
      {
         double x = 0;
         double y = 0;
         double count = 0;

         byte[] rawData = new byte[iplImage.ImageSize]; //imageSize uses byte alignment
         System.Runtime.InteropServices.Marshal.Copy(iplImage.ImageData, rawData, 0, iplImage.ImageSize);


         //Process image rawData to get a 2 x 2 binary matrix
         int nl = iplImage.Height;
         int nc = iplImage.Width * iplImage.NChannels;
         int step = iplImage.WidthStep; // because of alignment
         int stride = 0;

         for (int i = 0; i < nl; i++) // walk through rows of image
         {
            stride = i * step;
            for (int k = 0, j = 0; j < nc; j += iplImage.NChannels, k++) // walk through columns
            {
               if (rawData[j + stride] != 0 ||
                   rawData[j + 1 + stride] != 0 ||
                   rawData[j + 2 + stride] != 0) // if none in the 3 channels is 0
               {
                  x += k; // k is x position in image
                  y += i; // i is y position in image
                  count += 1; // then update counter

                  //motionCopy.Circle(new CvPoint(k, i), 1, CvColor.Red, 1);
               }
            }
         }

         Point CurrentCentroid = new Point(0, 0);
         // if any motion pixels were found (i.e., any motion occurred)
         // then we have a new centroid for the motion:
         if (count > 0)
            // new centroid is the center of all the x and y coordinates of
            // the motion pixels in the image
            CurrentCentroid = new Point((int)(x / count), (int)(y / count));
         else
            CurrentCentroid = LastCentroid; // otherwise, no new centroid        

         return CurrentCentroid;

      }

      /// <summary>
      /// Rotate
      /// </summary>
      /// <param name="P"></param>
      /// <param name="O"></param>
      /// <param name="Theta"></param>
      /// <returns></returns>
      private Point Rotate(Point P, Point O, double Theta)
      {
         Point R = new Point(0, 0);
         R.X = (int)(Math.Cos(Theta) * (P.X - O.X) - Math.Sin(Theta) * (P.Y - O.Y) + O.X);
         R.Y = (int)(Math.Sin(Theta) * (P.X - O.X) + Math.Cos(Theta) * (P.Y - O.Y) + O.Y);

         return R;
      }

      /// <summary>
      /// Get energy level
      /// </summary>
      /// <param name="iplImage"></param>
      /// <returns></returns>
      private double getEnergyLevel(IplImage iplImage)
      {
         //Marshal the image rawData into a byte array
         byte[] rawData = new byte[iplImage.ImageSize]; //imageSize uses byte alignment
         System.Runtime.InteropServices.Marshal.Copy(
             iplImage.ImageData, rawData, 0, iplImage.ImageSize);

         double energy = 0;
         foreach (int x in rawData)
         {
            if (x != 0)
               energy += 1;
         }
         energy = energy / (double)rawData.Length;
         return energy;

         /*
         string str = "";
         for (int i = 500; i < 900; i++)
         {
             str += Convert.ToString(rawData[i]) + " ";
         }
         return str;
         */
         /*            

         //Process image rawData to get a 2 x 2 binary matrix
         int nl = iplImage.height;
         int nc = iplImage.width * iplImage.nChannels;
         int step = iplImage.widthStep; // because of alignment
         int stride = 0;

         for (int i = 0; i < nl; i++)
         {
             stride = i * step;
             for (int k = 0, j = 0; j < nc; j += iplImage.nChannels, k++)
             {
                 if (rawData[j + stride] != 0 || rawData[j + 1 + stride] != 0 || rawData[j + 2 + stride] != 0)
                 {
                     imageMatrix[i][k] = 1;
                 }
                 else
                 {
                     imageMatrix[i][k] = 0;
                 }
             }
         }

         //Process the matrix. Flatten it in both dimensions, add these values to the input vector
         //the input array to the classifier
         object[] input = new object[image.Size.height + image.Size.width];
         int inputIndex = 0;
         for (int i = 0; i < image.Size.height; i++)
         {
             int horizontalValue = 0;
             int verticalValue = 0;
             for (int j = 0; j < image.Size.width; j++)
             {
                 horizontalValue += imageMatrix[i][j];
                 verticalValue += imageMatrix[j][i];
             }
             input[inputIndex] = (double)horizontalValue;
             input[inputIndex + 1] = (double)verticalValue;
             inputIndex += 2;
         }

            
          */
      }

      /// <summary>
      /// update motion history image (mhi)
      /// </summary>
      /// <param name="newFrame"></param>
      /// <param name="newMotionImage"></param>
      /// <param name="diff_threshold"></param>
      private void update_mhi(IplImage newFrame, IplImage newMotionImage,
          int diff_threshold)
      {
         // get current time in milliseconds:
         double timestamp = System.Diagnostics.Process.GetCurrentProcess().
                UserProcessorTime.TotalMilliseconds;
         CvSize size = newFrame.Size; // get current frame size

         // set IDX1 to LAST, declare IDX2
         //int i, idx1 = last, idx2; // original
         int idx1 = last;
         int idx2;
         // and i declared in for loop below
         IplImage silh; // silhouette image

         // if this is the first time through, or if the size
         // of MHI frames has changed, need to initialize the
         // ring buffer, the MHI, and the mask
         if (mhi == null || mhi.Size.Width != size.Width
                || mhi.Size.Height != size.Height)
         {
            if (buf == null)
            {
               buf = new IplImage[this.CYC_FRAME_BUF];
            }

            for (int i = 0; i < CYC_FRAME_BUF; i++)
            {
               buf[i] = new IplImage(size, BitDepth.U8, 1);
               buf[i].Zero();
            }

            mhi = new IplImage(size, BitDepth.F32, 1);
            mhi.Zero();
            mask = new IplImage(size, BitDepth.U8, 1);
         }

         // convert frame to grayscale -- takes input frame, Fn
         // saves the grayscale version to the LAST position in BUF
         newFrame.CvtColor(buf[last], ColorConversion.BgrToGray);

         // set IDX2 to the new frame (the frame after LAST, Fn)
         // TODO but that doens't make sense if input frame is Fn
         // and is saved to LAST in previous line
         idx2 = (last + 1) % CYC_FRAME_BUF;

         // set LAST to IDX2 for next time through this function, so that
         // LAST is the index of the previous frame (Fn-1)
         last = idx2;

         silh = buf[idx2]; // silhouette mask is the 

         // get absolute difference between image IDX1 in BUF (Fn-1)
         // and image IDX2 in BUF (Fn)
         // to get silhouette image
         buf[idx1].AbsDiff(buf[idx2], silh); // source, destination

         // threshold silhouette image - removes noise by filtering out
         // pixels with too small or too large of values
         silh.Threshold(silh, diff_threshold, THRESHOLD_MAX_VALUE,
                ThresholdType.Binary);

         // update motion history image MHI with SILH, given the current
         // time and the duration of the mhi "memory"
         OpenCvSharp.CvInvoke.cvUpdateMotionHistory(silh.CvPtr, mhi.CvPtr,
                timestamp, MHI_DURATION);

         // copy motion history image to mask array, with scaling 
         OpenCvSharp.CvInvoke.cvConvertScale(mhi.CvPtr, mask.CvPtr,
                255.0 / MHI_DURATION,
            (MHI_DURATION - timestamp) * 255.0 / MHI_DURATION);

         // reset output motion image to zero
         newMotionImage.Zero();
         // combine single-channeled images to get multichanneled image: 
         newMotionImage.CvtPlaneToPix(mask, mask, mask, null);
      }

      // classify...
      /*
     public string classify( SharperCVExtensions.MyCvImage image )
     {
        //Marshal the image rawData into a byte array
        SharperCV._IplImage iplImage = ( SharperCV._IplImage ) System.Runtime.InteropServices.Marshal.PtrToStructure( image.myArrHandle, typeof( SharperCV._IplImage ) );
        byte[] rawData = new byte[ iplImage.imageSize ]; //imageSize uses byte alignment
        System.Runtime.InteropServices.Marshal.Copy( iplImage.imageData, rawData, 0, iplImage.imageSize );

        //Process image rawData to get a 2 x 2 binary matrix
        int nl = iplImage.height;
        int nc = iplImage.width * iplImage.nChannels;
        int step = iplImage.widthStep; // because of alignment
        int stride = 0;

        for( int i = 0; i < nl; i++ )
        {
           stride = i * step;
           for( int k = 0, j = 0; j < nc; j += iplImage.nChannels, k++ ) 
           {			 
              if( rawData[ j + stride ] != 0 || rawData[ j + 1 + stride ] != 0 || rawData[ j + 2 + stride ] != 0 )
              {
                 imageMatrix[ i ][ k ] = 1;
              }
              else
              {
                 imageMatrix[ i ][ k ] = 0;
              }
           }
        }

        //Process the matrix. Flatten it in both dimensions, add these values to the input vector
        //the input array to the classifier
        object[] input = new object[ image.Size.height + image.Size.width  ];
        int inputIndex = 0;
        for( int i = 0; i < image.Size.height; i++ )
        {
           int horizontalValue = 0;
           int verticalValue = 0;
           for( int j = 0; j < image.Size.width; j++ )
           {
              horizontalValue += imageMatrix[ i ][ j ];
              verticalValue += imageMatrix[ j ][ i ];
           }
           input[ inputIndex ] = ( double ) horizontalValue;
           input[ inputIndex + 1 ] = ( double ) verticalValue;
           inputIndex += 2;
        }
			
        //Classify!
        int classId = ( int ) WEKAConversion.FacialExpressionMotionBooster.classify( input );

        string className = "";

        //Only classify if energy level is within a certain threshold
        int threshold = 0;
        foreach( int x in input )
           threshold += x;

        if( threshold > 100 && threshold < 500 )
        {
           switch( classId )       
           {         
              case 5:   
                 className = "Happy";
                 break;                  
              case 6:            
                 className = "Disgust";
                 break;          
              case 4:            
                 className = "Anger";
                 break;     
              case 3:
                 className = ""; //"Sadness";
                 break;
              case 2:
                 className = "Surprise";
                 break;
              case 1:
                 className = ""; //"Fear";
                 break;
           }
        }
        return className;
     }*/

      /// <summary>
      /// proportion energy
      /// </summary>
      /// <param name="curr"></param>
      /// <param name="prev"></param>
      /// <param name="prop2"></param>
      private void GetProportionEnergy(IplImage curr, IplImage prev,
         //out double prop1, 
         out double prop2)//, out double prop3)
      {
         // only using proportion2, so commented out the rest:

         // proportion 1
         //IplImage added = new IplImage(curr.Width, curr.Height, BitDepth.U8, 3);
         //IplImage subbed = new IplImage(curr.Width, curr.Height, BitDepth.U8, 3);
         //Cv.Add(curr, prev, added);
         //Cv.Sub(added, prev, subbed);
         //prop1 = getEnergyLevel(subbed);

         // prop 3
         //Cv.Sub(curr, prev, subbed);
         //prop3 = getEnergyLevel(subbed);
         
         // proportion 2
         IplImage diff = new IplImage(curr.Width, curr.Height, BitDepth.U8, 3);
         Cv.AbsDiff(prev, curr, diff);
         prop2 = getEnergyLevel(diff);

         //added.Dispose();
         //subbed.Dispose();
         diff.Dispose();
      }
   }
}

