using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain
{
    [DataContract]
    [TypeConverter(typeof(RoomTypeConverter))]
    public class RoomType
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Cost { get; set; }
    }

    public class RoomTypeConverter: TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType.Equals(typeof(string)))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var stringValue = value as string;
            if (string.IsNullOrEmpty(stringValue))
                return new RoomType();
            else
            {
                var parts = stringValue.Split('.');     
                if(parts.Count().Equals(3))
                    return new RoomType(){ Id = int.Parse(parts[0]), Name = parts[1], Cost = decimal.Parse(parts[2]) };
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
