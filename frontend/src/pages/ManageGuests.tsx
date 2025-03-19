import CurrentGuestTable from "../components/guests/CurrentGuestTable";
import GuestForm from "../components/guests/GuestForm";
import PreviousGuests from "../components/guests/PreviousGuests";
import { postData, getData } from "../services/api.ts";
import {useState, useEffect} from "react";
import useGlobalContext from "../hooks/useGlobalContext";

type GuestResponse = {
  data: Guest[];
}

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
export default function ManageGuests() {
  const [currentGuests, setCurrentGuests] = useState<Guest[]>([]);
  const [loading, setLoading] = useState(false);
  const { user } = useGlobalContext();

  //TODO:
  //  - connect api for submit and pull current guest list
  //  - send info to components
  //  - desktop version

  useEffect(() => {
    const fetchGuests = async () =>{
      if (!user?.userId) {
        console.error("User not logged in");
        return;
      }
      try {
        setLoading(true);
        const response = await getData<GuestResponse>(`/Guest?userId=${user?.userId}`)
        setCurrentGuests(response.data);
      } catch (error) {
        console.error("Error fetching guests:", error);
      } finally {
        setLoading(false);
      }
    };
    fetchGuests();
  }, [user?.userId]);

  async function handleSubmit(data: Guest) {
    if (!user?.userId) {
      console.error("User is not logged in, cannot submit guest");
      return;
    }
    try {
      const newGuest = await postData<Guest>("/guest/register-guest", {
        ...data,
        userId: user?.userId, 
      });
      setCurrentGuests((previousGuests) => [...previousGuests, newGuest])
  }catch (error) {
      console.error("Error submitting guest:", error);
    }
  }

  return (
    <div className="w-screen min-h-screen p-4">
      <h1 className="mt-12 mb-4 font-heading font-medium text-3xl">Manage Guests</h1>
      <div className="flex flex-col items-center ">
        <div className="w-full space-y-10 md:flex  md:space-x-10">
          <div className="flex-none w-full md:w-2/3 md:mt-10">
            <GuestForm onSubmit={handleSubmit} />
          </div>
          <div className="md:flex flex-col flex-grow space-y-8">
            <CurrentGuestTable currentGuests={currentGuests} />
            <PreviousGuests />
          </div>
        </div>
      </div>
    </div>
  )
}
