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
using System.Windows.Forms;

namespace MotionTracker
{
    static class Program
    {
        public static MotionTrackerUI motionTrackerUI = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // create and run motion tracker user interface
            motionTrackerUI = new MotionTrackerUI();
            motionTrackerUI.ShowDialog();

           // or, run simulation without UI (comment out above lines if so)
           //MotionTracker.MotionTracking motionTracker = new MotionTracking();
           //motionTracker.RunSimulation(false, false,
           //  false, false, Constants.SIM_OUT_PATH);

        }
    }
}
