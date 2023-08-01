# VncClass - Classroom Monitoring and Control Software

This software enables real-time monitoring and control of students' computers in a classroom setting. It consists of two components: a server application running on the teacher's computer and a client application running on each student's computer.

## Server (Teacher's Computer)

The server application allows the teacher to perform the following actions:

-   **View Student's Screens:** The teacher can view the screens of all connected students simultaneously. This allows the teacher to monitor the activities of each student in real-time.

-   **Control Student's Computers:** The teacher can take control of a student's computer remotely. This includes controlling the student's mouse and keyboard input. It enables the teacher to assist and guide students during their learning process.

-   **Send Messages:** The teacher can send messages to individual students or broadcast messages to all students. These messages can be used for announcements, instructions, or alerts.

-   **Share Teacher's Screen:** The teacher can share their own screen with the students. This feature is helpful for presenting lessons or demonstrating concepts to the entire class.

-   **Deny Input:** The teacher can disable keyboard and mouse input on the students' computers temporarily. This feature can be used to get the attention of the class or manage classroom distractions.

## Client (Student's Computer)

The client application, installed on each student's computer, enables the following functionalities:

-   **View Teacher's Screen:** Students can view the screen shared by the teacher. This allows students to follow along with lessons or presentations.

-   **Teacher Control:** The teacher, when granted permission, can remotely control the student's computer to provide guidance and support.

### How to Use

1. Open the solution in Visual Studio 2022.
2. Modify the Ip address inside VncClass/ClientForm.cs to the teacher's computer
3. Build and deploy on several computers.

### Notes

-   The software should be run as administrator on the student's computer.
-   The software may require additional permissions or configurations based on the operating systems and network environments in use.

### License

This software is distributed under the [MIT License](LICENSE.txt). Feel free to modify and use it according to your needs.

### Support and Contributions

For support, bug reports, or feature requests, please create an issue in the repository.
