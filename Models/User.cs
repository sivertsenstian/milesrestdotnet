using System.Collections.Generic; 

namespace MilesBoxApi.Models {

    public class User { 
        public int UserId {get; set;}
        public string Name {get; set;}
        public string ApiKey {get; set;}
        public bool IsAdmin {get; set;}
        public List<Box> Boxes {get; set;}
    }

    public class UserDto {
        public int id {get; set;}
        public string name {get; set;}
        public IEnumerable<BoxDto> boxes {get; set;}
    }
}
