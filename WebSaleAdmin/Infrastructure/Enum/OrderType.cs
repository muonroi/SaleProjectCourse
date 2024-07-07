namespace WebSaleAdmin.Infrastructure.Enum
{
    public enum OrderType
    {
        Waiting = 0, // chờ thanh toán <> chờ xác nhận
        Delivery = 1, // Đang giao
        Pickup = 2, // Đã nhận
        Cancel = 3, // Hủy
        Done = 4, // Thành công
        PaymentSuccess = 5, // Đã thanh toán 
    }
}
