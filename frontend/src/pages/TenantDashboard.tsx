import HeroCard from "../tenantDashboard/components/HeroCard";

const TenantDashboard = () => {
    const notifications = [
        { message: 'Your issue was updated' },
        { message: 'A package has arrived' },
        { message: 'Your lease expires soon' },
    ];

    return (
        < div className="min-h-screen bg-background" >
            {/* TODO: Create header component */}
            < header className="p-4 flex justify-between items-center" >
                <button className="p-2">
                    <div className="space-y-1">
                        <div className="w-6 h-0.5 bg-primary"></div>
                        <div className="w-6 h-0.5 bg-primary"></div>
                        <div className="w-6 h-0.5 bg-primary"></div>
                    </div>
                </button>
                <div className="flex justify-between w-full">
                    <h1 className="text-2xl font-bold">Welcome John</h1>
                    <p className="text-secondary">Unit 205</p>
                </div>
            </header >

            <div className="p-4 space-y-6">
                <HeroCard
                    title="Notifications"
                    count={3}
                    notifications={notifications}
                    onActionClick={(index) => console.log('Clicked notification', index)}
                    onViewAllClick={() => console.log('View all clicked')}
                />
            </div>
        </div >
    );
};

export default TenantDashboard;