﻿using ServiceTelecom.ViewModels;

namespace ServiceTelecom.Models
{
    public class ModelRadiostantionDataBaseModel : ViewModelBase
    {
        private int _id;
        private string _model;

        public ModelRadiostantionDataBaseModel(int idBase, string model)
        {
            IdBase = idBase;
            Model = model;
        }

        public int IdBase { get => _id; set { _id = value; OnPropertyChanged(nameof(IdBase)); } }
        public string Model { get => _model; set { _model = value; OnPropertyChanged(nameof(Model)); } }

        public override string ToString()
        {
            return $"{Model}";
        }
    }
}