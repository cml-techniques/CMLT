using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Constants
{
    public static class CMLTConstants
    {
        //Project List for loading sodetails_new.aspx
        public static string[] recentProjects 
        { 
            get {
                return new string[] { "123", "Traini", "Trial", "demo", "HMIM", "HMHS", "MOE", "11784", "AZC", "NCP", "MOE1", "PCD", "ARSD", "ABS", "12660", "DMRL", "KHUH", "KDT", "MON" };
                }
         }
        public static string[] PcdProjects   
        {
            get
            {
                return new string[] {  "PCD", "ARSD", "AFV"};
            }
        }

        //Project List for loading sodetails_new.aspx
        public static string[] hasBuilding
        {
            get
            {
                return new string[] { "HMIM", "HMHS" };
            }
        }

        ////Database connection 213.171.197.149,49296
        public static string serverName { get { return "213.171.197.149,49296"; } }
        public static string dbName { get { return "DBCML"; } }
        public static string dbUserName { get { return "CMLT"; } }
        public static string dbPassword { get { return "C!m@l#S$q%l"; } }


        //Database connection 213.171.197.40,49239
        //public static string serverName { get { return "213.171.197.40,49239"; } }
        //public static string dbName { get { return "DBCML"; } }
        //public static string dbUserName { get { return "sa"; } }
        //public static string dbPassword { get { return "Admin@123"; } }
        // For CML Dubai Server

     }      
 }