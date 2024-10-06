﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lab1
{
    public class DictionaryBaseType
    {
        [JsonPropertyName("Код")]
        [Display(Name = "Код")]
        public int Code { get; set; }

        [JsonPropertyName("Начало")]
        [JsonConverter(typeof(DateConverter))]
        [Display(Name = "Начало")]
        public DateTime BeginDate { get; set; }

        [JsonPropertyName("Окончание")]
        [JsonConverter(typeof(DateConverter))]
        [Display(Name = "Окончание")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("Наименование")]
        [Display(Name = "Наименование")]
        public string Name { get; set; } = string.Empty;

        public DictionaryBaseType()
        {
        }

    }
}
