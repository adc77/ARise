# ARise
ARise is an Image Detection AR app built using Unity, where users can point/scan any of the 8 images in the dataset and observe a 3D model in their surrounding just above that image. The app is built using the AR template, which consists of all the necessary libraries like AR Core, XR plugins, etc. It is currently available only for Android devices.

## Problem Statement
The app aims to improve visualization for humans, as it is often challenging for humans to visualize 3D diagrams through 2D images. It can also be useful in e-commerce, where customers can scan the product image and get a 3D model in their surrounding to observe, which can help in boosting sales.

## Usage
To use the app, download and set up **Unity's latest LTS version** (we used 2021.3.24f1 LTS). Then, clone this repository and run the project using Unity Hub. Once the project opens, go to File and choose Build & Run Settings. Make sure to choose the Android panel on the build & run window, and only one scene **"SampleScene"** is selected in the open scene section. Connect your Android device to your computer using USB, enable USB debugging, and give all the necessary permissions in the developer options of the android device. Press Build & Run, wait for the build, and once the app starts on your device, point it towards any of the images from the Target Image folder in the project and have fun with the 3D models!

## How it Works
The app works on image detection. First, it detects the image with the help of pixels & size of the image in the database. Then, once the match is found, it searches for the 3D model linked to the image matched in the database. The 3D model for that can be observed by the user through their camera in their surrounding.

We created folders for 3D models & Target Images, that act as the database for this app. And we wrote C# Scripts for the Image Tracking & Image Detection, Resizing of the 3D models on user input & Rotation of the 3D model at axes on left/right swipe input on the screen by the user.

## Authors
ARise was created by Suraj Barik, Satyajeet Sau, Abhay Singh, & Me. We created it to solve some problems mentioned above and to learn about Augmebted Reality & Unity. The project is open to contributions & new ideas.

## Acknowledgements
We would like to thank Unity, turbosquid.com, AR Core, and JIMS (Hackathon Organizer) for their direct/indirect help in the making of this project.

### Contact
To connect with us, reach out to me at amandogra2016@gmail.com or on Twitter @dograhere.

## Screenshots

**3D Model of a Shoe in AR**

![WhatsApp Image 2023-05-07 at 11 59 55](https://user-images.githubusercontent.com/118567905/236661691-82aaebc8-c884-40a7-b11d-549eab78fe34.jpg)


**Virus in AR**

![WhatsApp Image 2023-05-07 at 11 59 56](https://user-images.githubusercontent.com/118567905/236661738-6cdfc9f1-c4b2-4c65-9e23-d1b6a49b38ab.jpg)


**Car in AR**

![WhatsApp Image 2023-05-07 at 11 59 57](https://user-images.githubusercontent.com/118567905/236661772-aba7a18f-a14e-420e-a96a-ace954d741cb.jpg)

