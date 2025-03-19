import { useState } from "react";
import GuestProfileIcon from "./GuestProfileIcon";

interface Guest {
  firstName: string;
  lastName: string;
  phoneNumber: string;
  duration: string;
  carMake?: string;
  carModel?: string;
  carColor?: string;
  licensePlate?: string;
}
interface CurrentGuestTableProps {
  currentGuests?: Guest[];
}

export default function CurrentGuestTable({currentGuests = []}: CurrentGuestTableProps) {
  const [isExpanded, setIsExpanded] = useState(false);


  const displayedGuests = isExpanded ? currentGuests : currentGuests.slice(0, 3);

  const mapGuests = displayedGuests.map((guest, index) => (
    <tr key={index} className="py-2">
      <td className="p-2">
        <GuestProfileIcon />
      </td>
      <td className="p-2 text-nowrap"></td>
      <td className="font-bold p-2"></td>
    </tr>
  ));

  return (
    <div className="font-heading">
      <div className="flex justify-between mb-4">
        <h2 className="font-bold text-[#686868]">Current Guests</h2>
        <p className="font-bold cursor-pointer" onClick={() => setIsExpanded(!isExpanded)}>
          {isExpanded ? "View less" : "View all"}
        </p>
      </div>

      <div className="bg-white rounded-2xl min-h-40 p-3">
        <table className="w-full">
          <thead className="border-b border-gray-300">
            <tr className="py-2">
              <th className="p-2"></th>
              <th className="text-left p-2 font-medium">NAME</th>
              <th className="text-left p-2 font-medium text-sm">TIME REMAINING</th>
            </tr>
          </thead>
          <tbody>
            {mapGuests}
          </tbody>
        </table>
      </div>
    </div>
  );
}
