using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models {
    public class Patient {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public Patient(int id, string name, int age, string sex) {
            this.ID = id;
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }
    }
}