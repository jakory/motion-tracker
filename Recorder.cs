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
using OpenCvSharp;


namespace MotionTracker
{
    /// <summary>
    /// Recorder - using OpenCvSharp
    /// 
    /// Andrew Olney
    /// </summary>
	public class Recorder
	{
		public static string	FILENAME	= "record.avi";
		//public static int		CODEC		= 1482049860; //-1;//541215044;//808802372 808802372
      // use codec = -1 to prompt user to select codec
      // use codec = some four character code to indicate codec
        public static int CODEC = -1;
		public static int		FPS			= 15;
		public static int		WIDTH		= 640;
		public static int		HEIGHT		= 480;		

		public string filename = FILENAME;
		
		//private AVIWriter writer;

        private CvVideoWriter writer;

		public Recorder()
		{
			string filename = DateTime.Now.TimeOfDay.Ticks + ".avi";
			
			Console.WriteLine(filename);
			writer = new CvVideoWriter(filename, CODEC, FPS, new CvSize(WIDTH, HEIGHT));			
		}

		public Recorder(string filename)
		{											
			this.filename = filename;
            try
            {
                writer = new CvVideoWriter(filename, CODEC, FPS, new CvSize(WIDTH, HEIGHT));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
		}

      public Recorder(string filename, int fps, int width, int height)
      {
         this.filename = filename;
         try
         {
            writer = new CvVideoWriter(filename, CODEC, fps, new CvSize(width, height));
         }
         catch (Exception ex)
         {
            System.Diagnostics.Trace.WriteLine(ex.ToString());
         }
      }

        public void record(IplImage frame)
		{
			if(frame != null)
				writer.WriteFrame(frame);
			else
				throw new NullReferenceException();
		}

		public string getFilename()
		{
			return filename;
		}

		public void finalize()
		{
			//writer.forceClose();			
		}
	}
}
