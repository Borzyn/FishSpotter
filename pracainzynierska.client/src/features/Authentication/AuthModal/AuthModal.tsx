import Button from "../../../components/Button/Button";
import LineDivider from "../../../components/LineDivider/LineDivider";
import Modal from "../../../components/Modal/Modal";
import ModalHeader from "../../../components/Modal/ModalHeader";
import Login from "../Login/Login";

function AuthModal() {
  return (
    <>
      <Button buttonType="button" type="primary" onClick={() => {}}>
        Login
      </Button>

      <Modal onClick={() => {}}>
        <>
          <ModalHeader onClick={() => {}} title="Login" />
          <LineDivider />
          <Login />
        </>
      </Modal>
    </>
  );
}

export default AuthModal;
