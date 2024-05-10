# Upgrade to the version 2 for [Darknet.YOLOv3](https://github.com/12343954/Darknet.YoloV3)

[Features]
- Fixed `Detect(byte[] imageData)` method of `yolo_cpp_dll.dll`, the performance is close to the `Detect(string filename)`
- Remove third-party of `Alturos.Yolo.3.0.6-alpha.dll` dependencies
- Use the latest training dataset (2024-4-10)

[Usage]
1. Unzip the zip files to their folders
    - `./opencv_world420d.zip`
    - `./model/yolo-v3/yolov3.weights.zip`
    - `./model/new-coolooai/yolov3_custom_best.weights.zip`
2. F5 to run the code

[PS]  
- If you get the "yolo_cpp.dll.dll not found" error, you need to recompile the `yolo_v3.dll` with VS2019, not the VS2022.   
- Watch this: [Install & test YoloV3 on Windows 10](https://www.youtube.com/watch?v=zT8eDXpslXw)


<p><br /></p>
<p><br /></p>

<video width="800" height="600" controls>
    <source src="./images/demo.mp4" type="video/mp4">
</video>
<p>
<img alt="" src="./images/demo.jpg" width="800" />
</p>
<p>
<img alt="" src="./images/demo1.jpg" width="800" />
</p>
<img alt="" src="./images/demo2.jpg" width="800" />
</p>

## MIT LICENSE