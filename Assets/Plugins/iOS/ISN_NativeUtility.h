//
//  IOSNativeUtility.h
//  Unity-iPhone
//
//  Created by Osipov Stanislav on 4/29/14.
//
//

#import <Foundation/Foundation.h>

//#import "ISNDataConvertor.h"
#if UNITY_VERSION < 450
#include "iPhone_View.h"
#endif

@interface ISN_NativeUtility : NSObject

//@property (strong) SVProgressHUD *spinner;
@property (strong) UIActivityIndicatorView *spinner;

+ (id) sharedInstance;
+ (int) majorIOSVersion;

- (void) ShowSpinner:(float) currentProgress;
- (void) HideSpinner;

@end