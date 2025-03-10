import { InputHTMLAttributes } from 'react';

interface FormInputProps extends InputHTMLAttributes<HTMLInputElement> {
    label?: string;
    error?: string;
}

const FormInput = ({
    label,
    error,
    type = 'text',
    className = '',
    id,
    ...props
}: FormInputProps) => {
    const inputId = id || (label ? label.toLowerCase().replace(/\s+/g, '-') : undefined);

    return (
        <div className="mb-4">
            {label && (
                <label htmlFor={inputId} className="block text-black text-left mb-2">
                    {label}
                </label>
            )}
            <input
                id={inputId}
                type={type}
                className={`
                    w-full 
                    px-0 
                    py-2 
                    bg-transparent 
                    text-black 
                    border-b 
                    border-primary 
                    focus:outline-none 
                    focus:border-primary 
                    placeholder:text-secondary 
                    ${className}`}
                {...props}
            />
            {error && <p className="mt-1 text-sm text-red-500">{error}</p>}
        </div>
    );
};

export default FormInput;