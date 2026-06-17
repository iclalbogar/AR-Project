# AR Hand Detection & Interactive Animal Sounds

## About the Project
This project is an Augmented Reality (AR) application that utilizes the MediaPipe Unity Plugin for real-time hand tracking. It creates an interactive environment where users can physically interact with virtual 3D animal models using their index finger to trigger specific audio responses.

Developed as part of the Computer Engineering curriculum at Çukurova University, the system processes a live camera feed to detect the user's hand. It identifies the tip of the index finger (landmark 8) and dynamically maps a physical collider (a sphere) to this coordinate. When the user "touches" an animal model in the scene via this collider, the corresponding animal sound is triggered.

## Technical Specifications
* **Real-Time Hand Tracking:** Utilizes the MediaPipe Hand Landmarker API to continuously track 21 distinct hand joint points (landmarks).
* **Dynamic Spatial Interaction:** The MobileHandLinker script maps the dynamic coordinates of the index finger to a 3D object (IndexFingerCollider) in the Unity workspace.
* **Event-Driven Audio System:** Trigger collision mechanics are attached to the animal models, ensuring accurate sound execution upon contact with the finger object.
* **Computer Vision & Rendering:** The live camera feed and landmark annotations are processed and rendered on the UI via cam2 and the Annotatable Screen.

## Installation & Setup
1. Clone this repository to your local machine.
2. Open the project using Unity 2022.3.x.
3. Ensure that the MediaPipe Unity Plugin is properly installed within the Packages directory.
4. In the Unity hierarchy, locate the Solution object. Navigate to the HandLandmarkerRunnerConfig component and assign the hand_landmarker.task file to the appropriate field.
5. Press the Play button in the Unity Editor to initialize your web camera and start the application.

## Project Team
* **Developer:** Esra İclal Boğar - [@esraiclal](https://github.com/esraiclal)
* **Project Advisor:** [@dryuemco](https://github.com/dryuemco)
