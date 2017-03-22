// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

struct _MonoMethod;
struct _MonoClass;
struct _MonoObject;

/*
* ������һ��MonoCall�Ļص�����
*/
struct MonoCallback 
{
	_MonoMethod* OnRegister;
	_MonoMethod* OnUnregister;
	_MonoMethod* Initialize;
	_MonoMethod* Uninitialize;
	_MonoMethod* BeginPlay;
	_MonoMethod* EndPlay;
	_MonoMethod* Tick;
	_MonoMethod* OnEvent;

	void Clear() 
	{
		OnRegister = NULL;
		OnUnregister = NULL;
		Initialize = NULL;
		Uninitialize = NULL;
		BeginPlay = NULL;
		EndPlay = NULL;
		Tick = NULL;
		OnEvent = NULL;
	}
};

/**
* ������MonoClass��Callback�Ķ�Ӧ��ϵ
*/
class MonoCallbackTable
{
public:
	//��ʼ��һ����Ļص�����
	static void CreateClassCallback(_MonoClass* klass);
	//�������еĻص�
	static void DestroyAllCallback();
	//����MonoCalss��ȡ��Ӧ��Callback
	static MonoCallback* GetCallbackByClass(_MonoClass* klass);
	//����MonoObject��ȡ��Ӧ��Callback
	static MonoCallback* GetCallbackByObject(_MonoObject* obj);
};
