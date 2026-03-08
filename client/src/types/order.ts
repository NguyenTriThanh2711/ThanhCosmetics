export interface OrderCategory {
  categoryId: number;
  categoryName: string;
}
export interface SkinType {
  skinTypeId: number;
  skinTypeName: string;
}

export interface SkinTypeWrapper {
  $id: string;
  $values: SkinType[];
}
export interface OrderDetail {
  orderDetailId: number;
  productId: number;
  productName: string;
  size: string;
  quantity: number;
  price: number;
  discount: number;
  productImage?: string;
  category: OrderCategory;
  skinTypes: SkinTypeWrapper;
}
export interface OrderDetailWrapper {
  $id: string;
  $values: OrderDetail[];
}
export interface Order {
  orderId: number;
  orderCode: string;
  fullName: string;
  address: string;
  phoneNumber: string;
  voucher: Voucher | null;
  shippingPrice: number;
  totalAmount: number;
  paymentMethodName: string;
  status: string;
  createdDate: string;
  details: OrderDetail[];
}
export interface PurchaseDetail {
  $id: string;
  orderId: number;
  orderCode: string;
  fullName: string;
  address: string;
  shippingPrice: number;
  paymentMethodName: string;
  voucher: Voucher | null;
  phoneNumber: string;
  totalAmount: number;
  status: string;
  createdDate: string;
  details: OrderDetailWrapper;
}
export interface Voucher {
  $id: string;
  voucherId: number;
  voucherName: string;
  voucherCode: string;
  description: string;
  discountAmount: number | 0;
  startDate: string;
  endDate: string;
  status: boolean;
  minimumPurchase: number;
}