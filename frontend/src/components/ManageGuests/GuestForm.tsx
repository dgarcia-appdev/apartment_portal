import { useState } from 'react';
import { ChevronUp } from 'lucide-react';
import { FormInput, FormPhoneInput, FormSelect } from '../form';

interface GuestFormProps {
  onSubmit: (data: {
    fullName: string;
    phoneNumber: string;
    duration: string;
    carMakeModel?: string;
    carColor?: string;
    licensePlate?: string;
  }) => void;
}

export default function GuestForm({ onSubmit }: GuestFormProps) {
  const [formData, setFormData] = useState({
    fullName: '',
    phoneNumber: '',
    duration: '4',
    carMakeModel: '',
    carColor: '',
    licensePlate: ''

  });

  const [errors, setErrors] = useState({
    fullName: '',
    phoneNumber: '',
    duration: '',
    carMakeModel: '',
    carColor: '',
    licensePlate: ''
  });

  const [showParkingFields, setShowParkingFields] = useState(false);



  const handleToggleParking = () => {
    setShowParkingFields(prev => !prev);
  };

  const parkingFields = showParkingFields && (
    <>
      <FormInput
        label="Car Make and Model"
        value={formData.carMakeModel || ''}
        onChange={(e) => handleChange('carMakeModel', e.target.value)}
        error={errors.carMakeModel}
        placeholder="Enter car make and model"
        className='border-b-gray-300'
      />
      <FormInput
        label="Car Color"
        value={formData.carColor || ''}
        onChange={(e) => handleChange('carColor', e.target.value)}
        error={errors.carColor}
        placeholder="Enter car color"
        className='border-b-gray-300'
      />
      <FormInput
        label="License Plate"
        value={formData.licensePlate || ''}
        onChange={(e) => handleChange('licensePlate', e.target.value)}
        error={errors.licensePlate}
        placeholder="Enter license plate"
        className='border-b-gray-300'
      />
    </>
  )

  const handleChange = (field: string, value: string) => {
    setFormData(prev => ({
      ...prev,
      [field]: value
    }));

    // Clears error when typing
    if (errors[field as keyof typeof errors]) {
      setErrors(prev => ({
        ...prev,
        [field]: ''
      }));
    }
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    const newErrors = {
      fullName: !formData.fullName ? 'Full name is required' : '',
      phoneNumber: !formData.phoneNumber ? 'Phone number is required' : '',
      duration: !formData.duration ? 'Duration is required' : '',
      carMakeModel: '',
      carColor: '',
      licensePlate: ''
    };

    if (showParkingFields) {
      newErrors.carMakeModel = !formData.carMakeModel ? 'Car make and model is required' : '';
      newErrors.carColor = !formData.carColor ? 'Car color is required' : '';
      newErrors.licensePlate = !formData.licensePlate ? 'License plate is required' : '';
    }

    setErrors(newErrors);

    //if no errors in array, call onSubmit function
    if (!Object.values(newErrors).some(error => error)) {
      onSubmit(formData);
    }
  };

  const durationOptions = [
    { value: '4', label: '4 hours' },
    { value: '12', label: '12 hours' },
    { value: '1', label: '1 day' },
  ];

  return (
    <form onSubmit={handleSubmit} className="w-full p-5 bg-white rounded-2xl ">
      <FormInput
        label="Full Name"
        value={formData.fullName}
        onChange={(e) => handleChange('fullName', e.target.value)}
        error={errors.fullName}
        placeholder="Enter guest's full name"
        required
        className='border-b-gray-300'
      />

      <FormPhoneInput
        label="Phone Number"
        value={formData.phoneNumber}
        onChange={(value) => handleChange('phoneNumber', value)}
        error={errors.phoneNumber}
        className='border-b-gray-300'
      />

      <FormSelect
        label="Duration"
        value={formData.duration}
        onChange={(e) => handleChange('duration', e.target.value)}
        error={errors.duration}
        options={durationOptions}
        className='border-b-gray-300'
      />

      <div className='flex space-x-2 cursor-pointer  w-fit mb-4' onClick={handleToggleParking} >
        <p className='font-bold'>Needs Parking?</p>
        <ChevronUp className={`transition-transform duration-300 ${showParkingFields ? 'rotate-180' : 'rotate-0'}`} />
      </div>

      {parkingFields}

      <div className="mt-6">
        <button
          type="submit"
          className="w-full bg-primary text-white py-2 px-4 rounded-full hover:bg-primary/90 transition-colors"
        >
          Add Guest
        </button>
      </div>
    </form>
  );
}

