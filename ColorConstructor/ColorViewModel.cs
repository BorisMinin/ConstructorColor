using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace ColorConstructor
{
    public class ColorViewModel : INotifyPropertyChanged
    {
        #region Переменные
        private Color currentColor; 
        private string _OutPutBrushStringValue; //Стороковое значение кисти    
        #endregion

        public ColorViewModel()
        {
            currentColor.A = 255;
            OutPutBrush = new SolidColorBrush(currentColor);
            _OutPutBrushStringValue = OutPutBrush.Color.ToString();
        }

        #region Свойства зависимости
        public SolidColorBrush OutPutBrush
        {
            set; get;
        }

        public double Red
        {
            set
            {
                currentColor.R = (byte)value;
                SetNewColor();
            }
            get { return currentColor.R; }
        }

        public double Green
        {
            set
            {
                currentColor.G = (byte)value;
                SetNewColor();
            }
            get { return currentColor.G; }
        }

        public double Blue
        {
            set
            {
                currentColor.B = (byte)value;
                SetNewColor();
            }
            get { return currentColor.B; }
        }

        public string OutPutBrushStringValue
        {
            set
            { _OutPutBrushStringValue = value; OnPropertyChanged("OutPutBrushStringValue"); }
            get { return _OutPutBrushStringValue; }
        }
        #endregion

        #region Методы
        private void SetNewColor()
        {
            OutPutBrush = new SolidColorBrush(currentColor);
            OutPutBrushStringValue = currentColor.ToString();
            OnPropertyChanged("OutPutBrush");
        }
        #endregion

        #region Реализация интерфейса INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged; //Вызывается когда происходит изминение свойства

        protected void OnPropertyChanged(string propertyName) //Вызывает событие изминения свойства
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}