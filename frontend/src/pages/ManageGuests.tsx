import GuestForm from "../components/ManageGuests/GuestForm";

export default function ManageGuests() {
  function handleSubmit(data: {
    fullName: string;
    phoneNumber: string;
    duration: string;
    carMakeModel?: string;
    carColor?: string;
    licensePlate?: string;
  }) {
    console.log(data)
  }
  return (
    <div className="w-screen min-h-screen p-4">
      <h1 className="mt-12 mb-4 font-heading font-medium text-3xl">Manage Guests</h1>
      <div className="flex flex-col items-center ">
        <div className="w-full">
          <GuestForm onSubmit={handleSubmit} />
        </div>

      </div>
    </div>
  )
}
