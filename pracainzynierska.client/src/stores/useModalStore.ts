import { create } from "zustand";

interface IModal {
  isModalOpen: boolean;

  setModalStatus: (status: boolean) => void;
}

export const useModalStore = create<IModal>((set) => ({
  isModalOpen: false,

  setModalStatus: (status: boolean) => set({ isModalOpen: status }),
}));
