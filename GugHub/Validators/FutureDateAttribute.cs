﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GugHub
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            var isValid = DateTime.TryParseExact(
                Convert.ToString(value),
                "dd/MM/yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out date);

            return (isValid && date > DateTime.Now);
        }
    }
}