import { useState } from 'react';
import Card from '../components/Card';
import {
    FormInput,
    FormSelect,
    FormPhoneInput,
} from '../components/form';

const FormDemo = () => {
    const [formData, setFormData] = useState({
        name: '',
        email: '',
        phone: '',
        password: '',
        date: '',
        type: '',
        description: '',
    });

    const handleChange = (field: string, value: string) => {
        setFormData(prev => ({ ...prev, [field]: value }));
    };

    return (
        <div className="min-h-screen bg-background p-8">
            <div className="w-full mx-auto space-y-8">
                <h1 className="text-2xl text-center font-bold mb-8">Form Components</h1>

                <Card className="p-8">
                    <h2 className="text-2xl font-semibold mb-6">Basic Form Fields</h2>

                    <FormInput
                        label="Name"
                        placeholder="Enter your name"
                        value={formData.name}
                        onChange={(e) => handleChange('name', e.target.value)}
                    />

                    <FormPhoneInput
                        label="Phone"
                        value={formData.phone}
                        onChange={(value) => handleChange('phone', value)}
                    />

                    <FormSelect
                        label="Select Service"
                        value={formData.type}
                        onChange={(e) => handleChange('type', e.target.value)}
                        options={[
                            { value: '', label: 'Select type' },
                            { value: 'type1', label: 'Type 1' },
                            { value: 'type2', label: 'Type 2' },
                            { value: 'type3', label: 'Type 3' },
                        ]}
                    />
                </Card>
            </div>
        </div >
    );
};

export default FormDemo;