using GameLauncher.Model;
using GameLauncher.Service;
using GameLauncher.Service.Interfaces;
using GameLauncher.WPF.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameLauncher.WPF.ViewModels
{
    public class ReviewViewModel : BaseViewModel
    {
        private IApplicationService _applicationService;

        private Review _review;
        public Review Review
        {
            get => _review;
            set
            {
                if (value == _review) return;
                _review = value;
                OnPropertyChanged();
            }
        }

        private string _appName;
        public string AppName
        {
            get => _appName;
            set
            {
                if (value == _appName) return;
                _appName = value;
                OnPropertyChanged();
            }
        }

        private bool _isNewReview;
        public bool IsNewReview
        {
            get => _isNewReview;
            set
            {
                if (value == _isNewReview) return;
                _isNewReview = value;
                OnPropertyChanged();
            }
        }

        private int _selectedGrade;
        public int SelectedGrade
        {
            get => _selectedGrade;
            set
            {
                if (value == _selectedGrade) return;
                _selectedGrade = value;
                OnPropertyChanged();
            }
        }


        private RelayCommand _changeGradeCommand;
        public RelayCommand ChangeGradeCommand
        {
            get
            {
                return _changeGradeCommand ??
                  (_changeGradeCommand = new RelayCommand(obj =>
                  {
                      var index = Convert.ToInt32(obj);
                      if (index == 0) Review.Grade = Model.Enum.ReviewGradeEnum.Positive;
                      else Review.Grade = Model.Enum.ReviewGradeEnum.Negative;
                  }));
            }
        }

        private RelayCommand _setReviewCommand;
        public RelayCommand SetReviewCommand
        {
            get
            {
                return _setReviewCommand ??
                  (_setReviewCommand = new RelayCommand(obj =>
                  {
                      SetReviewAsync();
                  }));
            }
        }

        private async void SetReviewAsync()
        {
            Review.Date = DateTime.Now;
            await _applicationService.SetReview(Review, IsNewReview);

            MessageBox.Show("Отзыв сохранен");
        }


        public ReviewViewModel(Review review, int appId)
        {
            _applicationService = App.serviceProvider.GetService<IApplicationService>();

            if (review == null)
            {
                Review = new Review();
                Review.ApplicationId = appId;
                Review.UserId = AccountService.CurrentUser.Id;
                SelectedGrade = 0;
            }
            else
            {
                Review = review;
                if (Review.Grade == 0)
                {
                    SelectedGrade = 0;
                }
                else
                {
                    SelectedGrade = 1;
                }
            }



            InitilizationAsync();
        }

        private async void InitilizationAsync()
        {
            AppName = (await _applicationService.GetApplication(Review.ApplicationId)).Name;
        }
    }
}
