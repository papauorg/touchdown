This project contains a library which provides basic functionality to use a plain area as a touchpad like the ones known from notebooks. For this
the Kinect Sensor has to be mounted on top of a table (or similar) so that it is able to capture the plain area from above. The depth sensor of the Kinect will be used to recognize
touch points of fingers with the table. The resulting data is provided for the developers. Additionally the library is capable of basic gesture recording and recognition that can be
used by developers for the execution of actions in their programs based on gestures entered by the user. For the recognition and processing of the raw sensor data several image proces-
sing algorithms were used.

## Platform
The idea was to enable this functionality on windows using microsofts SDK and using the Freenect library. Unfortunately the Freenect part was never properly implemented. So there only is support for it at the moment.

## Demo application
The project contains a demo application that uses the library to perform the sensor setup and basic gesture recording and recognition.

## Documentation
Documentation is avaliable as it was used in the thesis for which the project was created as PDF. It is only available in german. See the [PDF Documentation](https://github.com/papauorg/touchdown/blob/master/doc/TouchdownProjectDocumentation_de.pdf).

## Credits
Thanks to Jason M. Simanek for the football logo that I got from (via openclipart.org). http://openclipart.org/detail/102853/football-by-simanek

