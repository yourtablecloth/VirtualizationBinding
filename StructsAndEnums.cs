namespace VirtualizationBinding {
    // VZError.h
    public enum VZErrorCode : int {
        VZErrorInternal = 1,
        VZErrorInvalidVirtualMachineConfiguration = 2,
        VZErrorInvalidVirtualMachineState = 3,
        VZErrorInvalidVirtualMachineStateTransition = 4,
        VZErrorInvalidDiskImage = 5,

        // MacOS 12.0
        VZErrorVirtualMachineLimitExceeded = 6,

        // MacOS 13.0
        VZErrorNetworkError = 7,
        VZErrorOutOfDiskSpace = 8,
        VZErrorOperationCancelled = 9,
        VZErrorNotSupported = 10,

        // MacOS 14.0
        VZErrorSave = 11,
        VZErrorRestore = 12,

        /* macOS installation errors. */

        // MacOS 13.0
        VZErrorRestoreImageCatalogLoadFailed = 10001,
        VZErrorInvalidRestoreImageCatalog = 10002,
        VZErrorNoSupportedRestoreImagesInCatalog = 10003,
        VZErrorRestoreImageLoadFailed = 10004,
        VZErrorInvalidRestoreImage = 10005,
        VZErrorInstallationRequiresUpdate = 10006,
        VZErrorInstallationFailed = 10007,

        /* Network Block Device errors. */

        // MacOS 14.0
        VZErrorNetworkBlockDeviceNegotiationFailed = 20001,
        VZErrorNetworkBlockDeviceDisconnected = 20002,
    }
}
