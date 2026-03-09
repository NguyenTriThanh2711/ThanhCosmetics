import { create } from "zustand";
import { immer } from "zustand/middleware/immer";
import {
  initialProfile,
  profileActions,
  type ProfileActions,
  type ProfileState,
} from "./store/profile";
import {
  initialNotification,
  notificationActions,
  type NotificationActions,
  type NotificationState,
} from "./store/notification";
import {
  initialProducts,
  type ProductsActions,
  productsActions,
  type ProductsState,
} from "./store/product";
import {
  initialRoutine,
  routineActions,
  type RoutineActions,
  type RoutineState,
} from "./store/routine";
import { cartActions, initialCart, type CartActions, type CartState } from "./store/cart";
import type { Draft } from "immer";
import { initialLoading, type LoadingState } from "./store/loading";
import { brandsActions, initialBrands, type BrandsActions, type BrandsState } from "./store/brand";
import { initialOrder, orderActions, type OrderActions, type OrderState } from "./store/order";
import { initialVoucher, voucherActions, type VoucherActions, type VouchersState } from "./store/voucher";
import { initialPayment, paymentActions, type PaymentActions, type PaymentState } from "./store/payment";
import { filterActions, initialFilter, type FilterActions, type FilterState } from "./store/filterActions";

export interface State {
  loading: LoadingState;
  brands : BrandsState;
  notification: NotificationState;
  profile: ProfileState;
  products: ProductsState;
  voucher: VouchersState;
  cart: CartState;
  order: OrderState;
  routine: RoutineState;
  payment: PaymentState;
  filter: FilterState;
}

export type Actions = ProfileActions &
  NotificationActions &
  ProductsActions &
  CartActions &
  RoutineActions &
  BrandsActions &
  VoucherActions &
  OrderActions &
  PaymentActions &
  FilterActions;

export type Store = State & Actions;
export type StoreGet = () => Store;
export type StoreSet = (f: (state: Draft<State>) => void) => void;

export const useStore = create<Store, [["zustand/immer", never]]>(
  immer((set, get) => ({
    profile: initialProfile,
    ...profileActions(set, get),
    products: initialProducts,
    ...productsActions(set, get),
    notification: initialNotification,
    ...notificationActions(set, get),
    loading: initialLoading,
    ...cartActions(set, get),
    cart: initialCart,
    ...routineActions(set, get),
    routine: initialRoutine,
    ...brandsActions(set, get),
    brands: initialBrands,
    order: initialOrder,
    ...orderActions(set, get),
    voucher: initialVoucher,
    ...voucherActions(set, get),
    payment: initialPayment,
    ...paymentActions(set, get),
    filter: initialFilter,
    ...filterActions(set, get),
  }))
);