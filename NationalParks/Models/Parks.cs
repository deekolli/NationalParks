using System;
using System.Collections.Generic;

namespace NationalParks.Models
{
    // Model for parks data. These classes can be obtained by either using 
    // the Visual Studio editor (right-click -> Paste Special -> Paste Json as Classes)
    // or sites such as JsonToCSHarp



    public class Rootobject
    {
        public Metadata metadata { get; set; }
        public Result[] results { get; set; }
    }

    public class Metadata
    {
        public int page { get; set; }
        public int total { get; set; }
        public int per_page { get; set; }
    }

    public class Result
    {
        public LatestProgramsCip_4_Digit[] latestprogramscip_4_digit { get; set; }
    }

    public class LatestProgramsCip_4_Digit
    {
        public string code { get; set; }
        public string title { get; set; }
        public string ope6_id { get; set; }
        public int unit_id { get; set; }
        public School school { get; set; }
        public Credential credential { get; set; }
       
    }

    public class School
    {
        public string name { get; set; }
        public string type { get; set; }
        public int main_campus { get; set; }
    }

    public class Credential
    {
        public int level { get; set; }
        public string title { get; set; }
    }

   

   

    




   


   






    public class Parks
    {
        public Metadata metadata { get; set; }
        public List<Park> results { get; set; }
    }



   

    public class Park
    {
        public string schoolname { get; set; }
        public string schoolcity { get; set; }
        public string schoolstate { get; set; }
        public int id { get; set; }
    }


}
