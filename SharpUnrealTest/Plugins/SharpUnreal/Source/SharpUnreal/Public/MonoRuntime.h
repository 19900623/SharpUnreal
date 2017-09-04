#pragma once

struct _MonoObject;
struct _MonoMethod;
struct _MonoClass;
class UMonoComponent;

/**
* ����Mono������Ĵ�����C# dll����
*/
class SHARPUNREAL_API MonoRuntime
{
public:
	//����һ��ȫ��Mono����ʱ
	static int CreateInstance();
	//����ȫ��Mono����ʱ
	static void DestoryInstance();
	//��ȡMono����ʱ�ĵ���
	static MonoRuntime* Instance();
	//���¼������߼��ű�
	int ReloadAssembly();
	//�����༭���¿�ʼ���еİ���
	void OnBeginPIE(bool bIsSimulating);

	TArray<FString> GetAllMonoComponent();
	
	_MonoObject* CreateObject(const char * name);
	_MonoObject* CreateObjectFromEngine(const char * name);
	uint32_t RetainObject(_MonoObject* object);
	void FreeObject(uint32_t handle);

	void SetNativeHandler(_MonoObject* object, void* handler);

	void ResgisterComponent( UMonoComponent* const component);
	void UnResgisterComponent( UMonoComponent* const component);

	_MonoMethod* FindMethod(_MonoClass* klass,const char* name, int paramCount);
	_MonoMethod* FindMethodByObj(_MonoObject* object, const char* name, int paramCount);
	_MonoObject* InvokeMethod(_MonoMethod* method, void *obj, void **params);

	_MonoClass* FindClassByName(const char* name);

	MonoRuntime();

private:
	void CopyToTarget(const FString& source, const FString &target);
private:
	struct _MonoDomain*		m_RootDomain;
	struct _MonoDomain*		m_ChildDomain;
	struct _MonoAssembly*	m_MainAssembly;
	struct _MonoImage*		m_MainImage;
	
	struct _MonoAssembly*	m_EngineAssembly;
	struct _MonoImage*		m_EngineImage;

	TArray<FString> m_ComponentNames;
	TArray<UMonoComponent*> m_MonoComponents;
};
