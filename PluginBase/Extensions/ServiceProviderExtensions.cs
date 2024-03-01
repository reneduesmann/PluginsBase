namespace System;

public static class ServiceProviderExtensions
{
    public static TService GetService<TService>(this IServiceProvider serviceProvider)
        where TService : class
    {
        if(serviceProvider is null)
        {
            throw new ArgumentNullException(nameof(serviceProvider));
        }

        TService service = serviceProvider.GetService(typeof(TService)) as TService
            ?? throw new ArgumentNullException(nameof(TService));

        return service;
    }
}
