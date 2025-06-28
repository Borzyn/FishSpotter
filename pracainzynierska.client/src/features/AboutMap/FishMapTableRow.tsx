import { ArrowDownCircle, ArrowUpCircle } from "lucide-react";
import { AnimatePresence, motion } from "framer-motion";
import { useState } from "react";
import { useGetFishMapPosts } from "./useGetFishMapPosts";
import FishMapRow, { IPost } from "./FishMapRow";

function FishMapTableRow({
  mapName,
  fishName,
}: {
  mapName: string | undefined;
  fishName: string;
}) {
  const { data, isPending } = useGetFishMapPosts(fishName, mapName ?? "");
  const [openPosts, setOpenPosts] = useState(false);

  console.log(data);

  return (
    <li className="border-2">
      <div className="w-full grid grid-cols-[1fr_max-content] items-center gap-x-8 text-2xl font-medium bg-amber-400 py-2 px-4">
        <p>{fishName}</p>
        {isPending ? (
          "Ładowanie..."
        ) : (
          <button
            onClick={() => setOpenPosts((cur) => !cur)}
            className="relative top-[1px] cursor-pointer"
          >
            {!openPosts ? (
              <ArrowDownCircle size={36} />
            ) : (
              <ArrowUpCircle size={36} />
            )}
          </button>
        )}
      </div>

      <AnimatePresence>
        {openPosts && (
          <motion.div
            initial={{
              height: 0,
            }}
            animate={{
              height: "auto",
            }}
            exit={{
              height: 0,
            }}
            className="text-[22px] font-medium overflow-hidden flex flex-col gap-1.5"
          >
            {data?.map((post: IPost) => (
              <FishMapRow key={post.id} post={post} />
            ))}
          </motion.div>
        )}
      </AnimatePresence>
    </li>
  );
}

export default FishMapTableRow;
