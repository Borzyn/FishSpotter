import { useState } from "react";
import { Star } from "lucide-react";

interface StarRatingProps {
  totalStars?: number;
  initialRating?: number;
  onChange?: (rating: number) => void;
  size?: number;
  activeColor?: string;
  inactiveColor?: string;
}

export default function StarRating({
  totalStars = 5,
  initialRating = 0,
  onChange,
  size = 24,
  activeColor = "#FFD700",
  inactiveColor = "#D3D3D3",
}: StarRatingProps) {
  const [rating, setRating] = useState(initialRating);
  const [hoverRating, setHoverRating] = useState(0);

  const handleClick = (selectedRating: number) => {
    setRating(selectedRating);
    if (onChange) {
      onChange(selectedRating);
    }
  };

  return (
    <div className="flex flex-col items-center gap-4">
      <div className="flex">
        {[...Array(totalStars)].map((_, index) => {
          const starValue = index + 1;
          const isActive = hoverRating
            ? starValue <= hoverRating
            : starValue <= rating;

          return (
            <div
              key={index}
              className="cursor-pointer p-1"
              onClick={() => handleClick(starValue)}
              onMouseEnter={() => setHoverRating(starValue)}
              onMouseLeave={() => setHoverRating(0)}
            >
              <Star
                size={size}
                fill={isActive ? activeColor : "none"}
                stroke={isActive ? activeColor : inactiveColor}
                strokeWidth={1.5}
              />
            </div>
          );
        })}
      </div>
    </div>
  );
}
