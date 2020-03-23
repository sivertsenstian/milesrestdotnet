namespace MilesBoxApi.Models {

    public class Measurement { 
        public int MeasurementId {get; set;}

        public int BoxId {get; set;}
        public Box Box {get; set;}

        public int SensorId {get; set;}
        public Sensor Sensor {get; set;}

        public int TimeStamp {get; set;}
        public float Value {get; set;}
    }

}
