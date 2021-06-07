using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleCloudFirestorePSW
{
    [FirestoreData]
    public class Detainee
    {
        [FirestoreProperty]
        public string FirstName { get; set; }
        [FirestoreProperty]
        public string LastName { get; set; }
        [FirestoreProperty]
        public string ReasonForTheDetention { get; set; }

        public override string ToString()
        {
            return  FirstName + " " + LastName + " Powód zatrzymania: " + ReasonForTheDetention;
        }
    }
}
