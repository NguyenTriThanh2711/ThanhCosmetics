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

export interface State {
  loading: LoadingState;
  notification: NotificationState;
  profile: ProfileState;
  products: ProductsState;
  cart: CartState;
  routine: RoutineState;
}

export type Actions = ProfileActions &
  NotificationActions &
  ProductsActions &
  CartActions &
  RoutineActions;

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
  }))
);