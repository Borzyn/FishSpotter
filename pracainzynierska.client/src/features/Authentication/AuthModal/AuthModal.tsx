import { useState } from "react";
import Button from "../../../components/Button/Button";
import LineDivider from "../../../components/LineDivider/LineDivider";
import Modal from "../../../components/Modal/Modal";
import ModalHeader from "../../../components/Modal/ModalHeader";
import Login from "../Login/Login";
import Register from "../Register/Register";
import { useModalStore } from "../../../stores/useModalStore";

function AuthModal() {
  const [isModalRegister, setIsModalRegister] = useState<boolean>(false);
  const { isModalOpen, setModalStatus } = useModalStore();

  function toggleModalRegister() {
    setIsModalRegister(!isModalRegister);
  }

  function handleCloseModal() {
    setIsModalRegister(false);
    setModalStatus(false);
  }

  function handleOpenModal() {
    setModalStatus(true);
  }

  return (
    <>
      <Button buttonType="button" type="primary" onClick={handleOpenModal}>
        Login
      </Button>

      {isModalOpen && (
        <Modal onClick={handleCloseModal}>
          <>
            {!isModalRegister && (
              <>
                <ModalHeader onClick={handleCloseModal} title="Login" />
                <LineDivider
                  color="bg-slate-900"
                  margin="my-3.5"
                  height="h-0.5"
                />
                <Login toggleModal={toggleModalRegister} />
              </>
            )}
            {isModalRegister && (
              <>
                <ModalHeader onClick={handleCloseModal} title="Register" />
                <LineDivider
                  color="bg-slate-900"
                  margin="my-3.5"
                  height="h-0.5"
                />
                <Register toggleModal={toggleModalRegister} />
              </>
            )}
          </>
        </Modal>
      )}
    </>
  );
}

export default AuthModal;
