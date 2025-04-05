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
                <LineDivider />
                <Login toggleModal={toggleModalRegister} />
              </>
            )}
            {isModalRegister && (
              <>
                <ModalHeader onClick={handleCloseModal} title="Register" />
                <LineDivider />
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
