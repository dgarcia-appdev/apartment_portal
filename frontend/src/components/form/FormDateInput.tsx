import FormInput from './FormInput';

interface FormDateInputProps {
    label?: string;
    error?: string;
    value: string;
    onChange: (value: string) => void;
    className?: string;
    placeholder?: string;
    minDate?: string;
    maxDate?: string;
}

const FormDateInput = ({
    label,
    error,
    value,
    onChange,
    className = '',
    placeholder,
    minDate = '1900-01-01',
    maxDate = new Date().toISOString().split('T')[0],
    ...props
}: FormDateInputProps) => {
    const validateDate = (date: string) => {
        const parsedDate = new Date(date);
        const min = new Date(minDate);
        const max = new Date(maxDate);

        if (parsedDate < min) return "Date must be after 1900";
        if (parsedDate > max) return "Date cannot be in the future";
        return null;
    };

    const validationError = validateDate(value) || error;

    return (
        <FormInput
            type="date"
            label={label}
            error={validationError}
            value={value}
            placeholder={placeholder}
            onChange={(e) => onChange(e.target.value)}
            min={minDate}
            max={maxDate}
            className={`${className}`}
            {...props}
        />
    );
};

export default FormDateInput;
