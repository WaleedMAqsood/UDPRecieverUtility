# UDPRecieverUtility
This utilty listens to UDP (User Datagram Protocol) messages and saves them on a file created/selected by a user (UDP does not guarantee delivery) .
User can add/delete a list of socket addreses (IP address and port number) permanenlty in a list view for later use.The socket addreses(Ip address and Port number) are 
stored in a file created by the program in a local application data directory and not in a database.

Quick Demo


**Main Window:**
![MainWindow](https://user-images.githubusercontent.com/47106767/119208330-55dee180-ba67-11eb-8e5a-ffcf2ceb9112.png)


**Configuring Address **
![MainWindowMenu](https://user-images.githubusercontent.com/47106767/119208335-5f684980-ba67-11eb-8c95-9d27e77ef050.png)


**List View of previosuly saved addreses**
![Window1ListView](https://user-images.githubusercontent.com/47106767/119208344-6beca200-ba67-11eb-94ff-1d05f514fef3.png)


**Deleting a previously saved address**
![Window1Deleting](https://user-images.githubusercontent.com/47106767/119208370-87f04380-ba67-11eb-8bed-a821bdef0312.png)

![Window1ListViewDeleted](https://user-images.githubusercontent.com/47106767/119208358-7ad35480-ba67-11eb-8d40-f8e224724601.png)

**Add Address Window**
![Window2](https://user-images.githubusercontent.com/47106767/119208416-b3732e00-ba67-11eb-8bd6-524befb6992c.png)

**Adding a new address**
![Window2AddingAddress](https://user-images.githubusercontent.com/47106767/119208428-c128b380-ba67-11eb-836e-d25e8a7a5295.png)

**Address added and now selecting an address by clicking "Done" button to start listening for packets (Selecting an address enable the "Start extractin menu")**
![Window1SelectingandAddress](https://user-images.githubusercontent.com/47106767/119208460-e0274580-ba67-11eb-9729-771a591e10cc.png)

**Selecting a file to where the Messages will be saved**
![MainWindowStartDataExtraction](https://user-images.githubusercontent.com/47106767/119208575-7196b780-ba68-11eb-9127-fa9328c9c7c6.png)
![saveFile](https://user-images.githubusercontent.com/47106767/119208659-d8b46c00-ba68-11eb-9df1-1a32f03f0d14.png)

**Extraction Started after a file is selected/Created. The utility is now listening for incoming packets ("Stop" menu will be enabled)**
![Windows1ExtractionStarted](https://user-images.githubusercontent.com/47106767/119208724-144f3600-ba69-11eb-8ef7-317b26963f62.png)

**After Packets recieved **
![Windows1PacketsRecieved](https://user-images.githubusercontent.com/47106767/119208756-2cbf5080-ba69-11eb-8152-6a0fc7dd0feb.png)
![DataRecieved](https://user-images.githubusercontent.com/47106767/119208769-3a74d600-ba69-11eb-8fc8-4387de00467a.png)

**Stopping Extraction (it will result in the address configuration menu being diabled)**
![DataExtractionConfirmationpng](https://user-images.githubusercontent.com/47106767/119208835-70b25580-ba69-11eb-806c-cc93b46a0d6f.png)
![DataExtractionStopped](https://user-images.githubusercontent.com/47106767/119208855-7f007180-ba69-11eb-8efe-6836855a936c.png)


**Checcking the file to see if messages are recieved **
![DataRecieved](https://user-images.githubusercontent.com/47106767/119208858-8162cb80-ba69-11eb-9c8d-90c4fb62c201.png)


























