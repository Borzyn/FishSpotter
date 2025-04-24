import { ArrowDownCircle, ArrowUpCircle } from "lucide-react";
import { AnimatePresence, motion } from "framer-motion";
import { useState } from "react";

function FishMapTableRow() {
  const [openPosts, setOpenPosts] = useState(false);

  return (
    <li className="border-2">
      <div className="w-full grid grid-cols-[1fr_max-content_max-content] items-center gap-x-8 text-2xl font-medium bg-amber-400 py-2 px-4">
        <p>Nazwa Ryby</p>
        <p>Ilość postów: 100</p>
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
            className="text-2xl font-medium overflow-hidden"
          >
            <div className="py-2 px-4">
              <p>Show posts</p>
            </div>
          </motion.div>
        )}
      </AnimatePresence>
    </li>
  );
}

export default FishMapTableRow;
