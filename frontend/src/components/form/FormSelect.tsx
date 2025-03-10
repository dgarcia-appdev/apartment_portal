import { SelectHTMLAttributes } from "react";
import { ChevronDown } from "lucide-react";

interface FormSelectProps extends SelectHTMLAttributes<HTMLSelectElement> {
    label?: string;
    error?: string;
    options: Array<{ value: string; label: string }>;
    required?: boolean;
}

const FormSelect = ({
    label,
    error,
    options,
    className = '',
    id,
    ...props
}: FormSelectProps) => {
    const selectId = id || (label ? label.toLowerCase().replace(/\s+/g, '-') : undefined);


    return (
        <div className="mb-4">
            {label && (
                <label htmlFor={selectId} className="block text-black mb-2 text-left">
                    {label}
                </label>
            )}
            <div className="relative">
                <select
                    className={`
                        w-full 
                        px-0 
                        py-2 
                        bg-transparent 
                        text-secondary border-b 
                        border-primary 
                        focus:border-content-background
                        focus:outline-none appearance-none 
                        ${className}`}
                    {...props}>
                    {options.map((option) => (
                        <option key={option.value} value={option.value}>
                            {option.label}
                        </option>
                    ))}
                </select>
                <div className="absolute right-2 top-1/2 -translate-y-1/2 pointer-events-none">
                    <ChevronDown />
                </div>
            </div>
            {error && (
                <p className="mt-1 text-sm text-red-500">{error}</p>
            )}
        </div>
    );
};

export default FormSelect;