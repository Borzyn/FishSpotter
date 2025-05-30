import { create } from "zustand";

export interface IUser {
  username: string;
  rateSum: number;
  rateAmount: number;
  postsCount: number;
  posts: IPost[];
}

export interface IPost {
  id: string;
  userId: string;
  fishName: string;
  mapName: string;
  spot: ISpot;
  method: IMethod;
  baitId: string;
  bait: IBait;
  groundbaitId: string;
  groundbait: IGroundBait;
  methodName: string;
  rateSum: number;
  rateAmount: number;
}

export interface ISpot {
  id: string;
  xy: string;
  additionalInfo: number;
  map: string;
}

export interface IMethod {
  id: string;
  name: string;
  baitIds: string[];
  groundBaitId: string;
}

export interface IBait {
  id: string;
  name: string;
  size: number;
  methods: IMethod[];
}

export interface IGroundBait {
  id: string;
  ingredients: IIngredient[];
  methods: IMethod[];
}

export interface IIngredient {
  id: string;
  name: string;
  groundbaitModelId: string;
}

interface IUserState {
  user: IUser | null;

  login: (userData: IUser) => void;
  logout: () => void;
}

export const useUserStore = create<IUserState>((set) => ({
  user: JSON.parse(localStorage.getItem("user") as string) || null,

  login: (userData: IUser) => {
    set(() => ({ user: userData }));
    localStorage.setItem("user", JSON.stringify(userData));
  },

  logout: () => {
    set(() => ({ user: null }));
    localStorage.removeItem("user");
  },
}));
