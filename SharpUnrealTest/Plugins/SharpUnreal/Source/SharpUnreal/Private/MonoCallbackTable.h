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
	_MonoMethod* OnEventWithInt;
	_MonoMethod* OnEventWithString;
	_MonoMethod* OnEventWithVector;
	
	_MonoMethod* OnAppDeactivate;
	_MonoMethod* OnAppHasReactivated;	
	_MonoMethod* OnAppWillEnterBackground;
	_MonoMethod* OnAppHasEnteredForeground;	
	_MonoMethod* OnAppWillTerminate;

	
	_MonoMethod* OnComponentHit;
	_MonoMethod* OnComponentBeginOverlap;
	_MonoMethod* OnComponentEndOverlap;
	_MonoMethod* OnComponentWake;
	_MonoMethod* OnComponentSleep;
	_MonoMethod* OnParticleSpawn;
	_MonoMethod* OnParticleBurst;
	_MonoMethod* OnParticleDeath;
	_MonoMethod* OnParticleCollide;
	_MonoMethod* OnSystemFinished;
	_MonoMethod* OnAudioFinished;
	_MonoMethod* OnAudioPlaybackPercent;
	_MonoMethod* OnSequencerPlay;
	_MonoMethod* OnSequencerPause;
	_MonoMethod* OnSequencerStop;

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
		OnEventWithInt = NULL;
		OnEventWithString = NULL;
		OnEventWithVector = NULL;

		OnAppDeactivate = NULL;
		OnAppHasReactivated = NULL;
		OnAppWillEnterBackground = NULL;
		OnAppHasEnteredForeground = NULL;
		OnAppWillTerminate = NULL;

		OnComponentHit = NULL;
		OnComponentBeginOverlap = NULL;
		OnComponentEndOverlap = NULL;
		OnComponentWake = NULL;
		OnComponentSleep = NULL;
		OnParticleSpawn = NULL;
		OnParticleBurst = NULL;
		OnParticleDeath = NULL;
		OnParticleCollide = NULL;
		OnSystemFinished = NULL;
		OnAudioFinished = NULL;
		OnAudioPlaybackPercent = NULL;
		OnSequencerPlay = NULL;
		OnSequencerPause = NULL;
		OnSequencerStop = NULL;
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
