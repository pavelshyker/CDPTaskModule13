using System;
using System.Collections.Generic;

namespace TestWebProject.BO
{
    public class Email
    {
        private readonly string _emailAddress;
        private readonly string _emailSubject;
        private readonly string _emailText;

        public List<String> DataEmail { get; set; }

        public Email(string emailAddress, string emailSubject, string emailText)
        {
            this._emailAddress = emailAddress;
            this._emailSubject = emailSubject;
            this._emailText = emailText;

            DataEmail = new List<String> { this._emailAddress, this._emailSubject, this._emailText };
        }
    }
}