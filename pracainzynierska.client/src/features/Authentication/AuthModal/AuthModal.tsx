import { useState } from "react";
import Button from "../../../components/Button/Button";
import LineDivider from "../../../components/LineDivider/LineDivider";
import Modal from "../../../components/Modal/Modal";
import ModalHeader from "../../../components/Modal/ModalHeader";
import Login from "../Login/Login";
import Register from "../Register/Register";

function AuthModal() {
  const [isModalRegister, setIsModalRegister] = useState<boolean>(false);

  function toggleModalRegister() {
    setIsModalRegister(!isModalRegister);
  }

  return (
    <>
      <Button buttonType="button" type="primary" onClick={() => {}}>
        Login
      </Button>

      <Modal onClick={() => {}}>
        <>
          {!isModalRegister && (
            <>
              <ModalHeader onClick={() => {}} title="Login" />
              <LineDivider />
              <Login toggleModal={toggleModalRegister} />
            </>
          )}
          {isModalRegister && (
            <>
              <ModalHeader onClick={() => {}} title="Register" />
              <LineDivider />
              <Register toggleModal={toggleModalRegister} />
            </>
          )}
        </>
      </Modal>
    </>
  );
}

export default AuthModal;
