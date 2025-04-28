using System;
using AVFoundation;
using CoreMedia;
using CoreVideo;
using Foundation;
using ObjCRuntime;

namespace SDAVAssetExportSession
{

    // The first step to creating a binding is to add your native framework ("MyLibrary.xcframework")
    // to the project.
    // Open your binding csproj and add a section like this
    // <ItemGroup>
    //   <NativeReference Include="MyLibrary.xcframework">
    //     <Kind>Framework</Kind>
    //     <Frameworks></Frameworks>
    //   </NativeReference>
    // </ItemGroup>
    //
    // Once you've added it, you will need to customize it for your specific library:
    //  - Change the Include to the correct path/name of your library
    //  - Change Kind to Static (.a) or Framework (.framework/.xcframework) based upon the library kind and extension.
    //    - Dynamic (.dylib) is a third option but rarely if ever valid, and only on macOS and Mac Catalyst
    //  - If your library depends on other frameworks, add them inside <Frameworks></Frameworks>
    // Example:
    // <NativeReference Include="libs\MyTestFramework.xcframework">
    //   <Kind>Framework</Kind>
    //   <Frameworks>CoreLocation ModelIO</Frameworks>
    // </NativeReference>
    // 
    // Once you've done that, you're ready to move on to binding the API...
    //
    // Here is where you'd define your API definition for the native Objective-C library.
    //
    // For example, to bind the following Objective-C class:
    //
    //     @interface Widget : NSObject {
    //     }
    //
    // The C# binding would look like this:
    //
    //     [BaseType (typeof (NSObject))]
    //     interface Widget {
    //     }
    //
    // To bind Objective-C properties, such as:
    //
    //     @property (nonatomic, readwrite, assign) CGPoint center;
    //
    // You would add a property definition in the C# interface like so:
    //
    //     [Export ("center")]
    //     CGPoint Center { get; set; }
    //
    // To bind an Objective-C method, such as:
    //
    //     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
    //
    // You would add a method definition to the C# interface like so:
    //
    //     [Export ("doSomething:atIndex:")]
    //     void DoSomething (NSObject object, nint index);
    //
    // Objective-C "constructors" such as:
    //
    //     -(id)initWithElmo:(ElmoMuppet *)elmo;
    //
    // Can be bound as:
    //
    //     [Export ("initWithElmo:")]
    //     NativeHandle Constructor (ElmoMuppet elmo);
    //
    // For more information, see https://aka.ms/ios-binding
    //

    [BaseType(typeof(NSObject))]
    interface SDAVAssetExportSession
    {
        [Wrap("WeakDelegate")]
        SDAVAssetExportSessionDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<SDAVAssetExportSessionDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic, strong) AVAsset * asset;
        [Export("asset", ArgumentSemantic.Strong)]
        AVAsset Asset { get; }

        // @property (copy, nonatomic) AVVideoComposition * videoComposition;
        [Export("videoComposition", ArgumentSemantic.Copy)]
        AVVideoComposition VideoComposition { get; set; }

        // @property (copy, nonatomic) AVAudioMix * audioMix;
        [Export("audioMix", ArgumentSemantic.Copy)]
        AVAudioMix AudioMix { get; set; }

        // @property (copy, nonatomic) NSString * outputFileType;
        [Export("outputFileType")]
        string OutputFileType { get; set; }

        // @property (copy, nonatomic) NSURL * outputURL;
        [Export("outputURL", ArgumentSemantic.Copy)]
        NSUrl OutputURL { get; set; }

        // @property (copy, nonatomic) NSDictionary * videoInputSettings;
        [Export("videoInputSettings", ArgumentSemantic.Copy)]
        NSDictionary VideoInputSettings { get; set; }

        // @property (copy, nonatomic) NSDictionary * videoSettings;
        [Export("videoSettings", ArgumentSemantic.Copy)]
        NSDictionary VideoSettings { get; set; }

        // @property (copy, nonatomic) NSDictionary * audioSettings;
        [Export("audioSettings", ArgumentSemantic.Copy)]
        NSDictionary AudioSettings { get; set; }

        // @property (assign, nonatomic) CMTimeRange timeRange;
        [Export("timeRange", ArgumentSemantic.Assign)]
        CMTimeRange TimeRange { get; set; }

        // @property (assign, nonatomic) BOOL shouldOptimizeForNetworkUse;
        [Export("shouldOptimizeForNetworkUse")]
        bool ShouldOptimizeForNetworkUse { get; set; }

        // @property (assign, nonatomic) BOOL canPerformMultiplePassesOverSourceMediaData;
        [Export("canPerformMultiplePassesOverSourceMediaData")]
        bool CanPerformMultiplePassesOverSourceMediaData { get; set; }

        // @property (copy, nonatomic) NSArray * metadata;
        [Export("metadata", ArgumentSemantic.Copy)]
        AVMetadataItem[] Metadata { get; set; }

        // @property (readonly, nonatomic, strong) NSError * error;
        [Export("error", ArgumentSemantic.Strong)]
        NSError Error { get; }

        // @property (readonly, assign, nonatomic) float progress;
        [Export("progress")]
        float Progress { get; }

        // @property (readonly, assign, nonatomic) AVAssetExportSessionStatus status;
        [Export("status", ArgumentSemantic.Assign)]
        AVAssetExportSessionStatus Status { get; }

        // +(id)exportSessionWithAsset:(AVAsset *)asset;
        [Static]
        [Export("exportSessionWithAsset:")]
        NSObject ExportSessionWithAsset(AVAsset asset);

        // -(id)initWithAsset:(AVAsset *)asset;
        [Export("initWithAsset:")]
        IntPtr Constructor(AVAsset asset);

        // -(void)exportAsynchronouslyWithCompletionHandler:(void (^)(void))handler;
        [Export("exportAsynchronouslyWithCompletionHandler:")]
        void ExportAsynchronouslyWithCompletionHandler(Action handler);

        // -(void)cancelExport;
        [Export("cancelExport")]
        void CancelExport();
    }

    // @protocol SDAVAssetExportSessionDelegate <NSObject>
    [BaseType(typeof(NSObject))]
    [Model]
    interface SDAVAssetExportSessionDelegate
    {
        // @required -(void)exportSession:(SDAVAssetExportSession *)exportSession renderFrame:(CVPixelBufferRef)pixelBuffer withPresentationTime:(CMTime)presentationTime toBuffer:(CVPixelBufferRef)renderBuffer;
        [Abstract]
        [Export("exportSession:renderFrame:withPresentationTime:toBuffer:")]
        unsafe void RenderFrame(SDAVAssetExportSession exportSession, IntPtr pixelBuffer, CMTime presentationTime, IntPtr renderBuffer);
    }

}


