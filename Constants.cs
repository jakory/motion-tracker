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
using System.Linq;
using System.Text;

namespace MotionTracker
{
   public static class Constants
   {
      // sample input video
      public static String SAMPLE_VIDEO = "test.avi";
      public static String DEFAULT_OUTPUT_BASE_NAME = "video";

      // no live camera index
      public const int NO_LIVE_CAM = -2;

      // strings to append to output files
      public static String MOTION_OUTPUT = "-M.txt";
      public static String CENTROID_OUTPUT = "-C.txt";
      public static String FACE_OUTPUT = "-F.txt";
      public static String MOTION_SILH_OUTPUT = "-out.avi";

      // for moving time series graph
      public static int SERIES = 0;
      public static int LINES_X_AXIS = 5;
      public static int LINES_Y_AXIS = 5;
      public static double DEFAULT_X_AXIS_MAX = 100;
      public static double DEFAULT_Y_AXIS_MAX = 1.0;
      public static double DEFAULT_X_AXIS_MIN = 0;
      public static double DEFAULT_Y_AXIS_MIN = 0;

      // button text
      public static String IN_FILE_SELECT = "Select input file";
      public static String IN_FILE_SELECTED = "Input file selected";
      public static String IN_DIR_SELECT = "Select input directory";
      public static String IN_DIR_SELECTED = "Input directory selected";
      public static String OUT_DIR_SELECT = "Select output directory";
      public static String OUT_DIR_SELECTED = "Output directory selected";
      public static String LIVE_CAM_SELECT = "Capture from camera";
      public static String LIVE_CAM_SELECTED = "Capture from camera";

      public static String SAVE_FILE_SELECT = "Select location to save video (optional)";
      public static String SAVE_FILE_SELECTED = "Save location selected";

      public static String ABORT_TEXT = "Ab&ort";
      public static String STOP_CAM_TEXT = "Stop c&amera";

      public static String TEST_CAM_START = "Test c&amera";
      public static String TEST_CAM_STOP = "Stop c&amera";


      public enum Buttons { InFile, InDir, LiveCam, OutDir };

      // motion tracker internal parameters defaults
      public const double DEFAULT_MHI_DURATION = 1;
      public const int DEFAULT_N = 4; // number of cyclic frame buffer
      public const int DEFAULT_BINARY_THRESHOLD = 30;

      public const string DEFAULT_HAAR_XML_FILE = "haarcascade_frontalface_default.xml";
      public const double DEFAULT_HAAR_SCALE_FACTOR = 1.1;
      public const int DEFAULT_HAAR_MIN_NEIGHBORS = 2;
      public const int DEFAULT_HAAR_MIN_WIDTH = 110;
      public const int DEFAULT_HAAR_MIN_HEIGHT = 110;

      // simulation constants
      public const int NOISE_MIN = 0; //0 to 10%
      public const int NOISE_MAX = 0;
      public const int NOISE_INCR = 2;//1;
      public const int SPEED_MIN = 10; // 5; // % of diameter
      public const int SPEED_MAX = 25;
      public const int SPEED_INCR = 5;//20;
      public const int AREA_MIN = 10; // % of img size
      public const int AREA_MAX = 25; // <82% to keep r<((1/3)height)
      public const int AREA_INCR = 5;//10;
      public const int SIM_IMG_WIDTH = 160; //320; // orig 640x480
      public const int SIM_IMG_HEIGHT = 120; //240;
      public const double MHI_MIN = 60; //%speed //100; // milliseconds
      public const double MHI_MAX = 60;//200; //2100;// milliseconds
      public static double MHI_INCR = 2; //200; // milliseconds // **
      public const int BINTHR_MIN = 0; // can range from 0-255
      public const int BINTHR_MAX = 255;//255; 
      public const int BINTHR_INCR = 10;//25;
      public const int ITERATIONS = 10; //10; // 10 iterations per trial
      public const int SECONDS = 11; // 11 seconds at 30fps (cut off 1s)
      public const int SIM_FPS = 30; // frames per second to save sim video

      public const bool SHOW_SIM_BUTTON = false;
      public const string SIM_FILE_BASE = "sim";
      public const string SIM_FILE_OVERALL = "sim-overall-summary.txt";
      public const string SIM_FILE_TRIAL_SUMMARY_BASE = "sim-trial-summary";
      public const string SIM_OVERALL_HEADER = "Trial\tIteration\tImageWidth\t"
         + "ImageHeight\tCirclePercentArea"
         + "\tCircleRadius\tSpeedPercent\tSpeedPxPerSec\t"
         + "Noise\tBinaryThreshold\tMHIDurationPercent\tMHIDurationMilliSec\t"
         + "ActualMotionMean\tActualMotionStdev\t"
         + "EstimatedMotionMean\tEstimatedMotionStdev\tPearsonCorrelation";
      //public const string SIM_TRIAL_SUMMARY_HEADER = "Iteration\tImageWidth\t"
      //   + "ImageHeight\tRadius\tNoise\tSpeed\tMHIDuration"
      //   + "\tBinaryThreshold\t"
      //   + "ActualMotionMean\tActualMotionStdev"
      //   + "\tEstimatedMotionMean\tEstimatedMotionStdev"
      //   + "\tPearsonCorrelation";
      public static bool SAVE_SIM = false; // if true, saves sim to video file
      public const string SIM_OUT_PATH = 
         "Z:\\IIS-janus\\MotionTracker-stuff\\motion-tracking-sim-out\\";
         //"..\\..\\SimulationOutput\\";

      public const string SIM_OUTPUT = "-sim.avi";
      public static String MOTION_HEADER = "Frames\tActualMotionProp1"
         + "\tActualMotionProp2\tActualMotionThisFrame"
         + "\tEstimatedMotion\tEstimatedMotionProp1"
         + "\tEstimatedMotionProp2\tEstimatedMotionProp3";


   }
}
