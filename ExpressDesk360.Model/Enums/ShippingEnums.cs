using System.ComponentModel;

namespace ExpressDesk360.Model.Enums;

public static class ShippingEnums
{
    public enum ShippingType : int
    {
        [Description("Alıcı Ödemeli")]
        ReceiverPays = 1,

        [Description("Gönderen Ödemeli")]
        SenderPays = 2
    }
}
