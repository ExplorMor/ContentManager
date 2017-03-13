//
//  IOSNativeUtility.m
//  Unity-iPhone
//
//  Created by Osipov Stanislav on 4/29/14.
//
//

#import "ISN_NativeUtility.h"

@implementation ISN_NativeUtility

static ISN_NativeUtility *_sharedInstance;

+ (id)sharedInstance {
    
    if (_sharedInstance == nil)  {
        _sharedInstance = [[self alloc] init];
    }
    
    return _sharedInstance;
}

+ (int) majorIOSVersion {
    NSArray *vComp = [[UIDevice currentDevice].systemVersion componentsSeparatedByString:@"."];
    return [[vComp objectAtIndex:0] intValue];
}


- (void) ShowSpinner: ( float) currentProgress
{
    [[UIApplication sharedApplication] beginIgnoringInteractionEvents];
    
    if([self spinner] != nil) {
        return;
    }
    
    UIViewController *vc =  UnityGetGLViewController();

	[self setSpinner:[[UIActivityIndicatorView alloc] initWithActivityIndicatorStyle:UIActivityIndicatorViewStyleWhiteLarge]];
	
[[UIDevice currentDevice] beginGeneratingDeviceOrientationNotifications];

    NSArray *vComp = [[UIDevice currentDevice].systemVersion componentsSeparatedByString:@"."];
    if ([[vComp objectAtIndex:0] intValue] >= 8) {
        NSLog(@"iOS 8 detected");
        [[self spinner] setFrame:CGRectMake(0,0, vc.view.frame.size.width, vc.view.frame.size.height)];
    } else {
        if([[UIDevice currentDevice] orientation] == UIDeviceOrientationPortrait || [[UIDevice currentDevice] orientation] == UIDeviceOrientationPortraitUpsideDown) {
            NSLog(@"portrait detected");
            [[self spinner] setFrame:CGRectMake(0,0, vc.view.frame.size.width, vc.view.frame.size.height)];
            
        } else {
            NSLog(@"landscape detected");
            [[self spinner] setFrame:CGRectMake(0,0, vc.view.frame.size.height, vc.view.frame.size.width)];
        }

    }
	
    [self spinner].opaque = NO;
    [self spinner].backgroundColor = [UIColor colorWithWhite:0.0f alpha:0.0f];
    
    
    [UIView animateWithDuration:0.8 animations:^{
        [self spinner].backgroundColor = [UIColor colorWithWhite:0.0f alpha:0.5f];
    }];
	
	
    [vc.view addSubview:[self spinner]];
	[[self spinner] startAnimating];
	
    [self spinner];

	//	[SVProgressHUD setDefaultStyle:SVProgressHUDStyleDark];
	//	[SVProgressHUD setDefaultMaskType:SVProgressHUDMaskTypeBlack];
	
	
	//		[SVProgressHUD showProgress:0 status:@"Downloading File"];
	
	//		[SVProgressHUD showProgress:currentProgress status:@"Downloading File"];
}



- (void) HideSpinner {
	

	
    if([self spinner] != nil) {
        [[UIApplication sharedApplication] endIgnoringInteractionEvents];
        
//        [self spinner].backgroundColor = [UIColor colorWithWhite:0.0f alpha:0.5f];
        [UIView animateWithDuration:0.8 animations:^{
            [self spinner].backgroundColor = [UIColor colorWithWhite:0.0f alpha:0.0f];

        } completion:^(BOOL finished) {
            [[self spinner] removeFromSuperview];
#if UNITY_VERSION < 500
            [[self spinner] release];
#endif
     
            [self setSpinner:nil];
        }];
        
       
    }
//    [SVProgressHUD dismiss];
}

- (CGFloat) GetW {
    
    UIViewController *vc =  UnityGetGLViewController();
    
    bool IsLandscape;
    UIInterfaceOrientation orientation = [UIApplication sharedApplication].statusBarOrientation;
    if(orientation == UIInterfaceOrientationLandscapeLeft || orientation == UIInterfaceOrientationLandscapeRight) {
        IsLandscape = true;
    } else {
        IsLandscape = false;
    }
    
    CGFloat w;
    if(IsLandscape) {
        w = vc.view.frame.size.height;
    } else {
        w = vc.view.frame.size.width;
    }
    
    
    NSArray *vComp = [[UIDevice currentDevice].systemVersion componentsSeparatedByString:@"."];
    if ([[vComp objectAtIndex:0] intValue] >= 8) {
        w = vc.view.frame.size.width;
    }

    
    return w;
}


extern "C" {
    
    
	
    //--------------------------------------
	//  IOS Native Plugin Section
	//--------------------------------------

    void _ISN_ShowPreloader(float currentProgress) {
		[[ISN_NativeUtility sharedInstance] ShowSpinner: currentProgress];
    }
    
    
    void _ISN_HidePreloader() {
        [[ISN_NativeUtility sharedInstance] HideSpinner];
    }
    
    //--------------------------------------
	//  Native PopUps Plugin Section
	//--------------------------------------

    
    void _MNP_ShowPreloader(float currentProgress) {
        _ISN_ShowPreloader(currentProgress);
    }
    
    
    void _MNP_HidePreloader() {
        _ISN_HidePreloader();
    }
    
    
}
@end
