namespace CoolooAI.YOLOv3
{
    public class obj_box
    {
        public int row_id { get; set; }        //row_index + 1

        // (x,y) - top-left corner
        public int x { get; set; }

        // (x,y) - top-left corner
        public int y { get; set; }

        // (w, h) - width & height of bounded box
        public int w { get; set; }

        // (w, h) - width & height of bounded box
        public int h { get; set; }

        // confidence - probability that the object was found correctly
        public float prob { get; set; }

        // class of object - from range [0, classes-1]
        public int obj_id { get; set; }

        // class of object - from name list[obj_id]
        public string obj_name { get; set; } = "";

        // tracking id for video (0 - untracked, 1 - inf - tracked object)
        public int track_id { get; set; }      

        public int frames_counter { get; set; }

        public float x_3d { get; set; }
        public float y_3d { get; set; }

        public float z_3d { get; set; }  // 3-D coordinates, if there is used 3D-stereo camera

        public obj_box()
        {
        }
    }
}
