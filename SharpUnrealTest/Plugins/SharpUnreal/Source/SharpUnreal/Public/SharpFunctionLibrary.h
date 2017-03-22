#pragma once

#include "Kismet/BlueprintFunctionLibrary.h"
#include "SharpFunctionLibrary.generated.h"

/**
 * ��Ҫ����ʵ��C#����ͼ���໥ͨѶ
 */
UCLASS(ClassGroup = (SharpUnreal), meta = (BlueprintSpawnableComponent))
class SHARPUNREAL_API USharpFunctionLibrary : public UBlueprintFunctionLibrary
{
	GENERATED_BODY()
	
public:

	UFUNCTION(BlueprintCallable,Category="SharpUnreal")
	static void SendStringEvent(FString evt, FString data);
	
};
