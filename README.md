# MOTION TRACKER: A video-based software system for tracking motion over time
Authors: Jacqueline Kory Westlund, Sidney D'Mello, Andrew Olney.
Contact: jakory@media.mit.edu

This program was developed with Microsoft Visual C# 2010 on a 64-bit Windows 7 machine.


## System Requirements
The program has been tested on 64-bit Windows 7 Enterprise & Home Edition. It should run on 32-bit Windows 7. It may run on older or newer Windows machines, but this has not been tested.

- Microsoft .NET Framework 4.0. The program will prompt you to install this the first time you run it if necessary, and will take you to the [Microsoft .NET download page] (https://www.microsoft.com/download/en/details.aspx?id=17851 "Microsoft .NET download").

- You may need to install the [Visual C++ 2010 Redistributable Package] (https://www.microsoft.com/download/en/details.aspx?displayLang=en&id=5555)

- You may need to install new video codecs so that the program can decode/encode video files. Installing a program such as [ffdshow] (http://sourceforge.net/projects/ffdshow-tryout/) can install many of the relevant codecs for you.

## Installation
1.Download the MotionTrackerProgram.zip folder to your computer.
2.Un-zip the folder.
3.Double-click on the un-zipped folder.
4.Open the folder "MotionTrackerProgram."
5.Double-click the file "MotionTracker.exe" to run the program.

Note: If you download the source code, you can run the program by navigating to "MotionTracker\bin\x86\Release\" and double-clicking the file "MotionTracker.exe".


### Possible installation issues
If you download the zip, open the program, run the demo, but the program crashes when trying to process the demo video file, you may not have proper video codecs installed. Try installing a program such as [ffdshow] (http://sourceforge.net/projects/ffdshow-tryout/), which installs many of the relevant codecs.




## Run

### To run the program
1. Double-click the file "MotionTracker.exe" to run the program. The other files in the MotionTracker folder are needed for proper program execution, so do not move this file out of the folder and do not delete the other files.

2. The MotionTrackerUI window will open. This window has four panels. At the bottom right is the controls panel. You can use these buttons and check boxes to process videos or view the processing of a demonstration video. The other three panels will display visualizations of the video being processed.


### To run the demo
3. Check the boxes "Display visualization during processing" and "Display motion time series during processing".
4. Click the button "Run Demo".
5. In the top left panel of the MotionTrackerUI window, you will see the actual video that is being processed. The top right panel will display the motion silhouette. In the lower left panel, a moving graph of the amount of motion per frame will be displayed.


### Controls
The MotionTrackerUI Controls panel allows you to process a single video file, a directory of video files, or a live camera feed.

To select a single AVI video file to process, click "Select input file". 
To select a directory of AVI video files to process, click "Select input directory".
To select a live camera feed to process, click "Capture from camera".

You must select a location to save output files from the program. The program will automatically generate the motion time series and the centroid of motion time series. For example, if you select to process a file called "video.avi", the program will generate a file called "video-M.txt" with the motion time series, and a file called "video-C.txt" with the centroid time series. If you elect to save a video of the motion silhouette frames, this file will be saved to "video-out.avi". If you elect to save the time series of the face region to file, the output will be saved to "video-F.txt". If you are processing video from a live camera feed, you will have the option of choosing whether and where to save the video recorded. 

## Algorithm Settings

### Motion History Image Duration
1. MHI_DURATION: Default value 1000. "Memory" of motion history image in milliseconds, i.e., number of frames taken into account when determining pixel intensity in the current motion history image. If frame rate is 30 frames per second, setting this value to "1000" means 30 frames will be used.


### Binary Threshold
2. BINARY_THRESHOLD: Default value 30. After the silhouette mask is generated from the most recent video frame, the silhouette is thresholded to give a binary image. This value is the threshold.

### Haar Object Detection Settings
1. SCALE FACTOR: Default 1.1. How quickly to increase the scale for object detections in each pass over the image. Higher means faster, fewer passes, may miss objects. Lower means slower and more passes. OpenCv default is 1.1 (10% increase on each pass).
2. MIN NEIGHBORS: Default 2. Cutoff level for discarding or keeping groups of rectangles (found objects) based on the number of raw detections in the group. Merges groups of more than this value and discards groups with fewer. If detector misses many objects, lower this value.
3. MIN SIZE - WIDTH: Default 110. Set relative to the size of your image. If you have large images or large objects, you can increase this value. If you have smaller images or smaller objects, decrease. Smaller size takes longer. Also set in proportion to the size of the images in the Haar cascade xml files, so the aspect ratio stays the same.
4. MIN SIZE - HEIGHT: Default 110. Same as above.

## Simulation
A button on the GUI exists to start the simulations; however, this button is made invisible by default (change this setting in the Constants.cs file). In the Program.cs file, there is code commented out for running the simulations without the GUI. Simulation settings, such as the number of iterations to run, can be changed in the Constants.cs file. 

## Libraries
The MathNet.Numerics library (https://mathnetnumerics.codeplex.com/) is only used for calculating various statistics when running simulations. See MathNetNumerics-License.txt for licensing information.


## TODO

- Program crashes if relevant video codecs aren't installed, add proper error handling for that

# License
The MIT License (MIT)


Copyright (c) 2015 jakory



Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.



THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

