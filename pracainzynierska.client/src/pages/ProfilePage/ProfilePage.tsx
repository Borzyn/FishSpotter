import { useNavigate, useParams } from "react-router";
import Button from "../../components/Button/Button";
import Table from "../../components/Table/Table";
import { useUserStore } from "../../stores/useUserStore";
import { useAccountInformations } from "../../features/Account/useAccountInformations";

import { useEffect } from "react";
import Loader from "../../components/Loaders/Loader/Loader";

const tableHeaders = [
  "Ryba",
  "Łowisko",
  "Metoda",
  "Ocena",
  "Lokalizacja",
  "Odnośnik",
];

function ProfilePage() {
  const { username } = useParams();
  const { user } = useUserStore();
  const navigate = useNavigate();
  const isOwnProfile = user?.username === username;

  const { isGettingInformations, getUserInformations, userInformationsData } =
    useAccountInformations();

  useEffect(() => {
    if (username) {
      getUserInformations({ accountCheckedName: username });
    }
  }, [username, getUserInformations]);

  if (isGettingInformations) {
    return <Loader />;
  }

  if (!userInformationsData) {
    return <Loader />;
  }

  const { rateSum, postsCount, posts } = userInformationsData;

  return (
    <section className="w-full h-full mx-auto max-w-7xl">
      <div className="flex gap-1 justify-between items-center border-2 border-slate-900 bg-slate-900 text-sky-50 rounded-md py-4 px-8 mb-6">
              <h2 className="text-3xl">{username}</h2>
              
        {isOwnProfile && (
          <Button
            onClick={() => navigate("/profile/addpost")}
            buttonType="button"
            type="primary"
          >
            Dodaj wpis
          </Button>
              )}
             
      </div>

      <div className="flex gap-5 flex-col items-center mb-8.5 sm:flex-row justify-between sm:mb-15">
        <div className="flex gap-1 flex-col justify-center items-center border-2 border-slate-900 bg-slate-900 text-sky-50 rounded-md py-4 px-8">
          <p className="text-xl ">Ilość postów</p>
          <p className="text-4xl font-semibold">{postsCount}</p>
        </div>
        <div className="flex gap-1 flex-col justify-center items-center border-2 border-slate-900 bg-slate-900 text-sky-50 rounded-md py-4 px-8">
          <p className="text-xl ">Średnia ocena postów</p>
          <p className=" text-4xl font-semibold">{rateSum}</p>
        </div>
      </div>

      {posts && (
        <Table
          title="Twoje ostatnie posty"
          tableCells={posts}
          tableHeaders={tableHeaders}
        />
      )}
    </section>
  );
}

export default ProfilePage;
